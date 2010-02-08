using System;
using System.IO;
using EnvDTE;

namespace DotWeb.TemplateConfigurator.Tasks
{
    public class ChangeOutputPathTask : ITasks
    {
        private readonly Project _projectSource;
        private readonly Project _projectTarget;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeOutputPathTask"/> class.
        /// </summary>
        /// <param name="projectSource">The project source.</param>
        /// <param name="projectTarget">The project target.</param>
        public ChangeOutputPathTask(Project projectSource,Project projectTarget)
        {
            if(projectSource == null)
                throw new ArgumentNullException("projectSource");
            if(projectTarget == null)
                throw new ArgumentNullException("projectTarget");

            _projectSource = projectSource;
            _projectTarget = projectTarget;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public void Execute()
        {
            var targetOutputPath = _projectTarget.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath");
            var sourceOutputPath = _projectSource.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath");

            var targetProjectFileInfo = new FileInfo(_projectTarget.FileName);
            
            var targetDirectory = targetProjectFileInfo.Directory;
            
            if(targetDirectory == null)
                return;

            sourceOutputPath.Value = Path.Combine(@"..\" + targetDirectory.Name, Convert.ToString(targetOutputPath.Value));
        }
    }
}