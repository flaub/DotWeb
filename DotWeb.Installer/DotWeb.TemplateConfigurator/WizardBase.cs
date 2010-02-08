using System;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace DotWeb.TemplateConfigurator
{
    public abstract class WizardBase : IWizard
    {
        protected string ProjectName { get; private set; }

        protected _DTE Dte { get; private set; }

        /// <summary>
        /// Runs custom wizard logic at the beginning of a template wizard run.
        /// </summary>
        /// <param name="automationObject">The automation object being used by the template wizard.</param>
        /// <param name="replacementsDictionary">The list of standard parameters to be replaced.</param>
        /// <param name="runKind">A <see cref="T:Microsoft.VisualStudio.TemplateWizard.WizardRunKind"/> indicating the type of wizard run.</param>
        /// <param name="customParams">The custom parameters with which to perform parameter replacement in the project.</param>
        public virtual void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind,
            object[] customParams)
        {
            Dte = ( (_DTE)automationObject );
            ProjectName = replacementsDictionary.First(e => e.Key == "$projectname$").Value;
        }

        /// <summary>
        /// Runs custom wizard logic when a project has finished generating.
        /// </summary>
        /// <param name="project">The project that finished generating.</param>
        public virtual void ProjectFinishedGenerating(Project project)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when a project item has finished generating.
        /// </summary>
        /// <param name="projectItem">The project item that finished generating.</param>
        public virtual void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        /// <summary>
        /// Indicates whether the specified project item should be added to the project.
        /// </summary>
        /// <param name="filePath">The path to the project item.</param>
        /// <returns>
        /// true if the project item should be added to the project; otherwise, false.
        /// </returns>
        public virtual bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        /// <summary>
        /// Runs custom wizard logic before opening an item in the template.
        /// </summary>
        /// <param name="projectItem">The project item that will be opened.</param>
        public virtual void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        /// <summary>
        /// Runs custom wizard logic when the wizard has completed all tasks.
        /// </summary>
        public virtual void RunFinished()
        {
        }

        /// <summary>
        /// Finds the project.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        protected Project FindProject(Predicate<string> filter)
        {
            foreach(Project project in Dte.Solution.Projects)
                if(filter(project.Name))
                    return project;

            return null;
        }
    }
}