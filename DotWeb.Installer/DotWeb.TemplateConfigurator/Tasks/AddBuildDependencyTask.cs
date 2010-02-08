using System;
using EnvDTE;

namespace DotWeb.TemplateConfigurator.Tasks
{
    public class AddBuildDependencyTask : ITasks
    {
        private readonly Project _project1;
        private readonly Project _project2;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddBuildDependencyTask"/> class.
        /// </summary>
        /// <param name="project1">The project1.</param>
        /// <param name="project2">The project2.</param>
        public AddBuildDependencyTask(Project project1,Project project2)
        {
            if(project1 == null)
                throw new ArgumentNullException("project1");
            if(project2 == null)
                throw new ArgumentNullException("project2");

            _project1 = project1;
            _project2 = project2;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public void Execute()
        {
            var dte = _project1.DTE;
            var solutionBuild = dte.Solution.SolutionBuild;
            var dependencies = solutionBuild.BuildDependencies;

            var mvcDependencys = dependencies.Item(_project1.UniqueName);
            mvcDependencys.AddProject(_project2.UniqueName);
        }
    }
}