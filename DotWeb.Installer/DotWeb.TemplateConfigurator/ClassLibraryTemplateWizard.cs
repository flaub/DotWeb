using DotWeb.TemplateConfigurator.Tasks;

namespace DotWeb.TemplateConfigurator
{
    public class ClassLibraryTemplateWizard : WizardBase
    {
        /// <summary>
        /// Runs custom wizard logic when the wizard has completed all tasks.
        /// </summary>
        public override void RunFinished()
        {
            var scriptProject = FindProject(name => name.Equals(ProjectName));

            new FixDotWebInstallationPathTask(scriptProject).Execute();
        }
    }
}