﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BridgeStack.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Shared {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Shared() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BridgeStack.Resources.Shared", typeof(Shared).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to access_token.
        /// </summary>
        internal static string AccessTokenParameter {
            get {
                return ResourceManager.GetString("AccessTokenParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to key.
        /// </summary>
        internal static string AppKeyParameter {
            get {
                return ResourceManager.GetString("AppKeyParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to application/json; charset=utf-8.
        /// </summary>
        internal static string JsonMimeType {
            get {
                return ResourceManager.GetString("JsonMimeType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BridgeStack.
        /// </summary>
        internal static string LibraryName {
            get {
                return ResourceManager.GetString("LibraryName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to POST.
        /// </summary>
        internal static string PostMethod {
            get {
                return ResourceManager.GetString("PostMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to application/x-www-form-urlencoded.
        /// </summary>
        internal static string PostMimeType {
            get {
                return ResourceManager.GetString("PostMimeType", resourceCulture);
            }
        }
    }
}
