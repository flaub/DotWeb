using System;
using EnvDTE;

namespace DotWeb.TemplateConfigurator.Tasks
{
    public class ChangeStartupProjectTask : ITasks
    {
        private readonly Project _project;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeStartupProjectTask"/> class.
        /// </summary>
        /// <param name="project">The project.</param>
        public ChangeStartupProjectTask(Project project)
        {
            if(project == null)
                throw new ArgumentNullException("project");

            _project = project;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public void Execute()
        {
            var solutionBuild = _project.DTE.Solution.SolutionBuild;

            solutionBuild.StartupProjects = _project.FileName;
        }
    }
}