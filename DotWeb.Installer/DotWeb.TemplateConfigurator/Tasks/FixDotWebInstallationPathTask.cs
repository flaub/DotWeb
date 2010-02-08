using System;
using System.Collections.Generic;
using System.IO;
using EnvDTE;
using VSLangProj;

namespace DotWeb.TemplateConfigurator.Tasks
{
    public class FixDotWebInstallationPathTask : ITasks
    {
        private readonly VSProject _project;

        /// <summary>
        /// Initializes a new instance of the <see cref="FixDotWebInstallationPathTask"/> class.
        /// </summary>
        /// <param name="project">The project.</param>
        public FixDotWebInstallationPathTask(Project project)
        {
            if(project == null)
                throw new ArgumentNullException("project");

            _project = (VSProject)project.Object;
        }

        /// <summary>
        /// Gets the installation path from registry.
        /// </summary>
        /// <returns></returns>
        private static string GetInstallationPathFromRegistry()
        {
            // put registry loading code here
            return null;
        }

        /// <summary>
        /// Gets the dot web references.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Reference> GetDotWebReferences()
        {
            foreach(Reference reference in _project.References)
                if(reference.Path.Contains(@"\DotWeb\"))
                    yield return reference;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public void Execute()
        {
            var dotWebPath = GetInstallationPathFromRegistry();

            if(dotWebPath == null) // no registry entry provided, leave default
                return;

            foreach(var reference in GetDotWebReferences())
            {
                var oldPath = reference.Path;
                var referenceFileName = Path.GetFileName(oldPath);
                var newPath = Path.Combine(dotWebPath, referenceFileName);

                reference.Remove();
                var newReference = _project.References.Add(newPath);
                newReference.CopyLocal = true;
            }
        }
    }
}