﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleanArchMvc.Domain.Validation {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CleanArchMvc.Domain.Validation.ResourceErrorMessages", typeof(ResourceErrorMessages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id is required.
        /// </summary>
        public static string CATEGORY_ID_REQUIRED {
            get {
                return ResourceManager.GetString("CATEGORY_ID_REQUIRED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name is required.
        /// </summary>
        public static string CATEGORY_NAME_REQUIRED {
            get {
                return ResourceManager.GetString("CATEGORY_NAME_REQUIRED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name is too short, minimum is 3 characters.
        /// </summary>
        public static string CATEGORY_NAME_TOO_SHORT {
            get {
                return ResourceManager.GetString("CATEGORY_NAME_TOO_SHORT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid price.
        /// </summary>
        public static string INVALID_PRICE {
            get {
                return ResourceManager.GetString("INVALID_PRICE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Description is required.
        /// </summary>
        public static string PRODUCT_DESCRIPTION_REQUIRED {
            get {
                return ResourceManager.GetString("PRODUCT_DESCRIPTION_REQUIRED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name is too short, minimum is 5 characters.
        /// </summary>
        public static string PRODUCT_DESCRIPTION_TOO_SHORT {
            get {
                return ResourceManager.GetString("PRODUCT_DESCRIPTION_TOO_SHORT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id is required.
        /// </summary>
        public static string PRODUCT_ID_REQUIRED {
            get {
                return ResourceManager.GetString("PRODUCT_ID_REQUIRED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name is required.
        /// </summary>
        public static string PRODUCT_NAME_REQUIRED {
            get {
                return ResourceManager.GetString("PRODUCT_NAME_REQUIRED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name is too short, minimum is 3 characters.
        /// </summary>
        public static string PRODUCT_NAME_TOO_SHORT {
            get {
                return ResourceManager.GetString("PRODUCT_NAME_TOO_SHORT", resourceCulture);
            }
        }
    }
}
