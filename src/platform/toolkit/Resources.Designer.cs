﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.454
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nohros.Toolkit {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Nohros.Toolkit.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to 500 Bad Email Address..
        /// </summary>
        internal static string MailChecker_BadMailAddress {
            get {
                return ResourceManager.GetString("MailChecker_BadMailAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 511 The reply line is too long..
        /// </summary>
        internal static string MailChecker_BigReplyLine {
            get {
                return ResourceManager.GetString("MailChecker_BigReplyLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 420 Could not query DNS Server..
        /// </summary>
        internal static string MailChecker_DNSQuery {
            get {
                return ResourceManager.GetString("MailChecker_DNSQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 400 The string {0} is not a valid SMTP reply messsage.
        /// </summary>
        internal static string MailChecker_InvalidReply {
            get {
                return ResourceManager.GetString("MailChecker_InvalidReply", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 500 The supplied domain name was not in the correct form..
        /// </summary>
        internal static string MailChecker_InvDomain {
            get {
                return ResourceManager.GetString("MailChecker_InvDomain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 510 No Mail Server found..
        /// </summary>
        internal static string MailChecker_NoMxServer {
            get {
                return ResourceManager.GetString("MailChecker_NoMxServer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Socket Exception: {0}..
        /// </summary>
        internal static string MailChecker_Socket {
            get {
                return ResourceManager.GetString("MailChecker_Socket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &quot;{0}&quot; string does not represents a valid port number..
        /// </summary>
        internal static string Messaging_SMTP_InvalidPort {
            get {
                return ResourceManager.GetString("Messaging_SMTP_InvalidPort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The recipients of the message was not specified..
        /// </summary>
        internal static string Messaging_smtperr_NoRecipients {
            get {
                return ResourceManager.GetString("Messaging_smtperr_NoRecipients", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The message sender was not specified..
        /// </summary>
        internal static string Messaging_smtperr_NoSender {
            get {
                return ResourceManager.GetString("Messaging_smtperr_NoSender", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The address of the message sender was not specified..
        /// </summary>
        internal static string Messaging_smtperr_NoSenderAddress {
            get {
                return ResourceManager.GetString("Messaging_smtperr_NoSenderAddress", resourceCulture);
            }
        }
    }
}
