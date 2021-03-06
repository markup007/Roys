﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4963
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.1432.
// 

namespace tforConnector
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "tforservice", Namespace = "http://tempuri.org/")]
    public partial class tforservice : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private tforCredentials tforCredentialsValueField;

        private System.Threading.SendOrPostCallback CallWSOperationCompleted;

        /// <remarks/>
        public tforservice( String URL)
        {
            this.Url = URL;
        }

        public tforCredentials tforCredentialsValue
        {
            get
            {
                return this.tforCredentialsValueField;
            }
            set
            {
                this.tforCredentialsValueField = value;
            }
        }

        /// <remarks/>
        public event CallWSCompletedEventHandler CallWSCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("tforCredentialsValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CallWS", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CallWS(string Xml, string ClassName, string Mode)
        {
            object[] results = this.Invoke("CallWS", new object[] {
                    Xml,
                    ClassName,
                    Mode});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginCallWS(string Xml, string ClassName, string Mode, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("CallWS", new object[] {
                    Xml,
                    ClassName,
                    Mode}, callback, asyncState);
        }

        /// <remarks/>
        public string EndCallWS(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void CallWSAsync(string Xml, string ClassName, string Mode)
        {
            this.CallWSAsync(Xml, ClassName, Mode, null);
        }

        /// <remarks/>
        public void CallWSAsync(string Xml, string ClassName, string Mode, object userState)
        {
            if ((this.CallWSOperationCompleted == null))
            {
                this.CallWSOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCallWSOperationCompleted);
            }
            this.InvokeAsync("CallWS", new object[] {
                    Xml,
                    ClassName,
                    Mode}, this.CallWSOperationCompleted, userState);
        }

        private void OnCallWSOperationCompleted(object arg)
        {
            if ((this.CallWSCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CallWSCompleted(this, new CallWSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", IsNullable = false)]
    public partial class tforCredentials : System.Web.Services.Protocols.SoapHeader
    {

        private string userNameField;

        private string pwdField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public string UserName
        {
            get
            {
                return this.userNameField;
            }
            set
            {
                this.userNameField = value;
            }
        }

        /// <remarks/>
        public string Pwd
        {
            get
            {
                return this.pwdField;
            }
            set
            {
                this.pwdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    public delegate void CallWSCompletedEventHandler(object sender, CallWSCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CallWSCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CallWSCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}