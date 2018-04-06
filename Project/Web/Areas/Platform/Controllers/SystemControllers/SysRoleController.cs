﻿using IServices.Infrastructure;
using IServices.ISysServices;
using Models.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Areas.Platform.Helpers;
using Web.Helpers;

namespace Web.Areas.Platform.Controllers
{
    public class SysRoleController : Controller
    {
        private readonly ISysControllerService _sysControllerService;
        private readonly ISysRoleService _iSysRoleService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISysRoleSysControllerSysActionService _sysRoleSysControllerSysActionService;

        public SysRoleController(ISysRoleService iSysRoleService, IUnitOfWork unitOfWork, ISysControllerService sysControllerService, ISysRoleSysControllerSysActionService sysRoleSysControllerSysActionService)
        {
            _iSysRoleService = iSysRoleService;
            _unitOfWork = unitOfWork;
            _sysControllerService = sysControllerService;
            _sysRoleSysControllerSysActionService = sysRoleSysControllerSysActionService;
        }


        // GET: Admin/SysRole
        public ActionResult Index(string keyword, string ordering, int pageIndex = 1, bool export = false, bool search = false)
        {
            var model = _iSysRoleService.GetAll().Select(a => new { a.RoleName, a.SystemId, a.SysDefault, a.Id }).OrderBy(a => a.SystemId).Search(keyword);

            if (search)
            {
                model = model.Search(Request.QueryString);
            }
            if (!string.IsNullOrEmpty(ordering))
            {
                model = model.OrderBy(ordering, null);
            }
            if (export)
            {
                return model.ToExcelFile();
            }
            return View(model.ToPagedList(pageIndex));
        }





        public ActionResult Details(object id)
        {
            var item = _iSysRoleService.GetById(id);
            ViewBag.SysControllers = _sysControllerService.GetAll().ToList();
            return View(item);
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit");
        }

        public ActionResult Edit(string id)
        {
            var item = new SysRole();
            if (!string.IsNullOrEmpty(id))
            {
                item = _iSysRoleService.GetById(id);
            }
            ViewBag.SysControllers = _sysControllerService.GetAll(a => a.Enable).ToList();
            return View(item);
        }

        //
        // POST: /Platform/SysEnterprise/Edit/5

        [HttpPost]
        public async Task<ActionResult> Edit(string id, SysRole collection, IEnumerable<string> sysControllerSysActionsId)
        {
            if (string.IsNullOrEmpty(collection.RoleName))
            {
                ModelState.AddModelError("RoleName", "请填写角色名称");
            }

            if (!ModelState.IsValid)
            {
                Edit(id);
                return View(collection);
            }

            collection.Name = Guid.NewGuid().ToString();

            if (!string.IsNullOrEmpty(id))
            {
                //清除原有数据
                _sysRoleSysControllerSysActionService.Delete(a => a.RoleId.Equals(id));
            }

            _iSysRoleService.Save(id, collection);

            if (sysControllerSysActionsId != null)
            {
                foreach (var sysControllerSysActionId in sysControllerSysActionsId)
                {
                    _sysRoleSysControllerSysActionService.Save(null, new SysRoleSysControllerSysAction
                    {
                        RoleId = collection.Id,
                        SysControllerSysActionId = sysControllerSysActionId
                    });
                }
            }

            await _unitOfWork.CommitAsync();

            return new EditSuccessResult(id);

        }


        //
        // POST: /Platform/SysEnterprise/Delete/5

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            var item = _iSysRoleService.GetById(id);

            if (item.SysDefault)
                throw new Exception("系统默认角色不可删除！");

            _iSysRoleService.Delete(item);

            await _unitOfWork.CommitAsync();

            return new DeleteSuccessResult();
        }
    }
}
