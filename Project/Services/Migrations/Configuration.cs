using System.Data.Entity.Migrations;
using System.Linq;
using Models.SysModels;

namespace Services.Migrations
{
    public class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            this.CommandTimeout = 180;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            #region ��ҵ

            var sysEnterprises = new[]
            {
                new SysEnterprise
                {
                    Id = "defaultEnt",
                    EnterpriseName = "ϵͳĬ����ҵ"
                },
                new SysEnterprise
                {
                    Id = "TestEnt",
                    EnterpriseName = "������ҵ"
                }
            };
            context.SysEnterprises.AddOrUpdate(a => new { a.Id }, sysEnterprises);

            #endregion

            #region SysArea

            var sysAreas = new[]
            {
                new SysArea
                {
                    AreaName = "Platform",
                    Name = "����ƽ̨",
                    SystemId = "002"
                }
            };
            context.SysAreas.AddOrUpdate(a => new { a.AreaName, a.Name, a.SystemId }, sysAreas);

            #endregion

            #region SysAction

            var sysActions = new[]
            {
                new SysAction
                {
                    Name = "�б�",
                    ActionName = "Index",
                    SystemId = "001",
                    System = true
                },
                new SysAction
                {
                    Name = "��ϸ",
                    ActionName = "Details",
                    SystemId = "003",
                    System = true
                },
                new SysAction
                {
                    Name = "�½�",
                    ActionName = "Create",
                    SystemId = "004",
                    System = true
                },
                new SysAction
                {
                    Name = "�༭",
                    ActionName = "Edit",
                    SystemId = "005",
                    System = true
                },
                new SysAction
                {
                    Name = "ɾ��",
                    ActionName = "Delete",
                    SystemId = "006",
                    System = true
                },
                new SysAction
                {
                    Name = "����",
                    ActionName = "Report",
                    SystemId = "007",
                    System = true
                }
            };
            context.SysActions.AddOrUpdate(a => new { a.ActionName }, sysActions);

            #endregion

            #region SysController

            var sysControllers = new[]
            {
                #region �������� 100
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "����ƽ̨-����",
                    ControllerName = "Index",
                    ActionName="Index",
                    SystemId = "100",
                    Display = false
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "ʹ�ð���",
                    ControllerName = "Help",
                    SystemId = "100200",
                    Display = false
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "��Ϣ����",
                    ControllerName = "MyMessage",
                    SystemId = "100300",
                    Display = false
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "�޸�����",
                    ControllerName = "ChangePassword",
                    SystemId = "100400",
                    Display = false
                },

                #endregion other                

                #region ������� 800
                  new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "�������",
                   SystemId = "800",
                    Ico = "fa-line-chart",
                    Display = true
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "��������",
                    ControllerName = "TaskCenter",
                    SystemId = "800200",
                    Ico = "fa-tasks"
                },
                #endregion


                #region �û����� 900
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "�û�����",
                    SystemId = "900",
                    Ico = "fa-users",
                    Display = true
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "��֯�ܹ�",
                    ControllerName = "SysDepartment",
                    SystemId = "900200",
                    Ico = "fa-dot-circle-o"
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "��ɫ����",
                    ControllerName = "SysRole",
                    SystemId = "900300",
                    Ico = "fa-dot-circle-o"
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "�û�����",
                    ControllerName = "SysUser",
                    SystemId = "900400",
                    Ico = "fa-dot-circle-o"
                },

                #endregion

                
                #region ϵͳ�������� 950
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "ϵͳ����",
                    SystemId = "950",
                    Ico = "fa-cog"
                }, new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "ϵͳ����",
                    ControllerName = "WebConfigAppSetting",
                    SystemId = "950200",
                    Ico = "fa-cubes"
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "��������",
                    ControllerName = "SysAction",
                    SystemId = "950300",
                    Ico = "fa-th-large"
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "ϵͳģ��",
                    ControllerName = "SysController",
                    SystemId = "950400",
                    Ico = "fa-puzzle-piece"
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "������Ϣ",
                    ControllerName = "SysHelp",
                    SystemId = "950900",
                    Ico = "fa-info-circle"
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "������Ϣ",
                    ControllerName = "SysHelp",
                    SystemId = "950900100",
                    Ico = "fa-info-circle"
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "������Ϣ����",
                    ControllerName = "SysHelpClass",
                    SystemId = "950900200",
                    Ico = "fa-info-circle"
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "�û���־",
                    ControllerName = "SysUserLog",
                    SystemId = "950990",
                    Ico = "fa-calendar"
                },
                new SysController
                {
                    SysAreaId = sysAreas.Single(a => a.AreaName == "Platform").Id,
                    Name = "ϵͳ��־",
                    ControllerName = "SysLog",
                    SystemId = "950995",
                    Ico = "fa-file-text-o"
                },
                #endregion
            };

            context.SysControllers.AddOrUpdate(
                a => new { a.SysAreaId, a.SystemId }, sysControllers);

            #endregion

            #region SysControllerSysAction

            var sysControllerSysActions = (from sysAction in sysActions.Where(a => a.System)
                                           from sysController in sysControllers
                                           select
                                           new SysControllerSysAction
                                           {
                                               SysActionId = sysAction.Id,
                                               SysControllerId = sysController.Id
                                           }).ToArray();

            context.SysControllerSysActions.AddOrUpdate(a => new { a.SysActionId, a.SysControllerId },
                sysControllerSysActions);

            #endregion

            #region ģ������Action

            context.SysControllerSysActions.AddOrUpdate(a => new { a.SysActionId, a.SysControllerId });

            #endregion

            #region ��ɫ����

            //�Զ�������Ҫ��Ȩ�����ù���
            var ids4SysControllerSysActions = sysControllerSysActions.Select(a => a.Id).ToList();
            context.SysRoleSysControllerSysActions.RemoveRange(
                context.SysRoleSysControllerSysActions.Where(
                    rc =>
                        rc.SysControllerSysAction.SysAction.System &&
                        !ids4SysControllerSysActions.Contains(rc.SysControllerSysActionId)).ToList());
            //context.Commit(); ʵʱ�ύһ���Ƿ��ܽ���ظ������⣿
            foreach (var ent in sysEnterprises)
            {
                var sysRoleUser = new SysRole
                {
                    Id = "User-" + ent.Id,
                    Name = ent.EnterpriseName + "ע���û�",
                    RoleName = "ע���û�",
                    SysDefault = true,
                    SystemId = "000",
                    EnterpriseId = ent.Id
                };
                context.SysRoles.AddOrUpdate(sysRoleUser);

                //����ϵͳ����Ա
                var sysRole = new SysRole
                {
                    Id = "admin-" + ent.Id,
                    Name = ent.EnterpriseName + "ϵͳ����Ա",
                    RoleName = "ϵͳ����Ա",
                    SysDefault = true,
                    SystemId = "999",
                    EnterpriseId = ent.Id
                    //ϵͳ����Ա�Զ��������Ȩ��
                    //SysRoleSysControllerSysActions = (from aa in sysControllerSysActions select new SysRoleSysControllerSysAction { SysControllerSysActionId = aa.Id, RoleId = "admin-" + ent.Id }).ToArray()
                };
                context.SysRoles.AddOrUpdate(sysRole);
                //ϵͳ����Ա�Զ��������Ȩ��
                var sysRoleSysControllerSysActions = (from aa in sysControllerSysActions
                                                      select
                                                      new SysRoleSysControllerSysAction
                                                      {
                                                          SysControllerSysActionId = aa.Id,
                                                          RoleId = sysRole.Id
                                                      }).ToArray();
                context.SysRoleSysControllerSysActions.AddOrUpdate(rc => new { rc.RoleId, rc.SysControllerSysActionId },
                    sysRoleSysControllerSysActions);
            }

            #endregion
        }
    }
}