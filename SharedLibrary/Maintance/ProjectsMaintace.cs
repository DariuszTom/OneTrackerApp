using DbDataLibrary.Models.Entities;
using SharedLibrary.Misc.MessegeSender;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Maintance
{
    public class ProjectsMaintace
    {
        #region Constructor
        public ProjectsMaintace(List<Project> proToMaintance)
        {
            this.proToMaintance = proToMaintance;
        }
        #endregion
        #region Fields
        private List<Project> proToMaintance;
        #endregion
        #region Methods
        public async Task LastUpdateNothificaction(byte days, IMailSender mailSender)
        {
            var validPeriod = DateTime.UtcNow.AddDays(-days);
            foreach (var project in proToMaintance)
            {
                if (project.UpdateTime is null || project.Developer is null) continue;

                else if (project.UpdateTime > validPeriod) continue;

                else await SendInfo(project, validPeriod, mailSender);
            }
        }
        private async Task SendInfo(Project pro, DateTime validPeriod, IMailSender mailSender)
        {
            var sb = new StringBuilder();
            sb.Append($"Dear {pro.DeveloperNavigation.EmpName}");
            sb.AppendLine("This is automatic response due to fact: ");
            sb.AppendLine($"That you have not make any changes to your project " +
                $"id{pro.Id} Name: {pro.ProjectName}. After valid period {validPeriod:f} ");

            mailSender.CreateMail("No progress", sb);
            await mailSender.SendMail(new string[] { pro.DeveloperNavigation.Mail });

        }
        #endregion
    }
}
