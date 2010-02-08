using DotWeb.TemplateConfigurator.Tasks;

namespace DotWeb.TemplateConfigurator
{
    public class MvcTemplateWizard : WizardBase
    {
        /// <summary>
        /// Runs custom wizard logic when the wizard has completed all tasks.
        /// </summary>
        public override void RunFinished()
        {
            var scriptProject = FindProject(name => name.Equals(ProjectName + ".Script"));
            var mvcProject = FindProject(name => name.Equals(ProjectName));

            new FixDotWebInstallationPathTask(scriptProject).Execute();
            new ChangeStartupProjectTask(mvcProject).Execute();
            new AddBuildDependencyTask(mvcProject, scriptProject).Execute();
            new ChangeOutputPathTask(scriptProject,mvcProject).Execute();
        }
    }
}