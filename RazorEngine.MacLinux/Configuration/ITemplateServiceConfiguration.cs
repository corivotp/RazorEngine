﻿namespace RazorEngine.Configuration
{
    using System;
    using System.Collections.Generic;

    using Compilation;
    using Compilation.Inspectors;
    using Templating;
    using Text;
    using RazorEngine.Compilation.ReferenceResolver;
    using Microsoft.AspNetCore.Razor.Language;

    /// <summary>
    /// Defines the required contract for implementing template service configuration.
    /// </summary>
    public interface ITemplateServiceConfiguration
    {
        #region Properties
        /// <summary>
        /// Gets the activator.
        /// </summary>
        IActivator Activator { get; }

        /// <summary>
        /// Gets or sets whether to allow missing properties on dynamic models.
        /// </summary>
        bool AllowMissingPropertiesOnDynamic { get; }

        /// <summary>
        /// Gets the base template type.
        /// </summary>
        Type BaseTemplateType { get; }
        
#if !RAZOR4
        /// <summary>
        /// Gets the code inspectors.
        /// </summary>
        [Obsolete("This API is obsolete and will be removed in the next version (Razor4 doesn't use CodeDom for code-generation)!")]
        IEnumerable<ICodeInspector> CodeInspectors { get; }
#endif

        /// <summary>
        /// Gets the reference resolver.
        /// </summary>
        IReferenceResolver ReferenceResolver { get; }
        
        /// <summary>
        /// Gets the caching provider.
        /// </summary>
        ICachingProvider CachingProvider { get; }

        /// <summary>
        /// Gets the compiler service factory.
        /// </summary>
        ICompilerServiceFactory CompilerServiceFactory { get; }

        /// <summary>
        /// Gets whether the template service is operating in debug mode.
        /// </summary>
        bool Debug { get; }

        /// <summary>
        /// Loads all dynamic assemblies with Assembly.Load(byte[]).
        /// This prevents temp files from being locked (which makes it impossible for RazorEngine to delete them).
        /// At the same time this completely shuts down any sandboxing/security.
        /// Use this only if you have a limited amount of static templates (no modifications on rumtime), 
        /// which you fully trust and when a seperate AppDomain is no solution for you!.
        /// This option will also hurt debugging.
        /// 
        /// OK, YOU HAVE BEEN WARNED.
        /// </summary>
        bool DisableTempFileLocking { get; }

        /// <summary>
        /// Gets the encoded string factory.
        /// </summary>
        IEncodedStringFactory EncodedStringFactory { get; }
            
        /// <summary>
        /// Gets the language.
        /// </summary>
        Language Language { get; }

        /// <summary>
        /// Gets the namespaces.
        /// </summary>
        ISet<string> Namespaces { get; }
#if !NO_CONFIGURATION
        /// <summary>
        /// Gets the template resolver.
        /// </summary>
        [Obsolete("Please use the TemplateManager property instead")]
        ITemplateResolver Resolver { get; }
#endif
        /// <summary>
        /// Gets the template resolver.
        /// </summary>
        ITemplateManager TemplateManager { get; }

#pragma warning disable CS0618 // Type or member is obsolete
        /// <summary>
        /// Callback to register custom Model directives or configure the razor engine builder in another form.
        /// </summary>
        /// <value>
        /// An callback that receives the builder
        /// </value>
        Action<IRazorEngineBuilder> ConfigureCompilerBuilder { get; }
#pragma warning restore CS0618 // Type or member is obsolete
        #endregion

    }
}
