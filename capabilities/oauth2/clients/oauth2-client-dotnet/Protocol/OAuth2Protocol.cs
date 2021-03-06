﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atricore.OAuth2Protocol.AccessTokenRequestor
{


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:wsdl", ConfigurationName = "AccessTokenRequestor.OAuthPortType")]
    public interface OAuthPortType
    {

        // CODEGEN: Generating message contract since the operation AuthorizationRequest is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.oasis-open.org/committees/security", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OAuthResponseAbstractType))]
        OAuth2Protocol.AccessTokenRequestor.AuthorizationResponseOutput AuthorizationRequest(OAuth2Protocol.AccessTokenRequestor.AuthorizationRequestInput request);

        // CODEGEN: Generating message contract since the operation AccessTokenRequest is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.oasis-open.org/committees/security", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OAuthResponseAbstractType))]
        OAuth2Protocol.AccessTokenRequestor.AccessTokenResponseOutput AccessTokenRequest(OAuth2Protocol.AccessTokenRequestor.AccessTokenRequestInput request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public partial class AuthorizationRequestType : OAuthRequestAbstractType
    {

        private string responseTypeField;

        private string clientIdField;

        private string clientSecretField;

        private string redirectUriField;

        private string scopeField;

        private string stateField;

        public AuthorizationRequestType()
        {
            this.responseTypeField = "code";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("code")]
        public string responseType
        {
            get
            {
                return this.responseTypeField;
            }
            set
            {
                this.responseTypeField = value;
                this.RaisePropertyChanged("responseType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string clientId
        {
            get
            {
                return this.clientIdField;
            }
            set
            {
                this.clientIdField = value;
                this.RaisePropertyChanged("clientId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string clientSecret
        {
            get
            {
                return this.clientSecretField;
            }
            set
            {
                this.clientSecretField = value;
                this.RaisePropertyChanged("clientSecret");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string redirectUri
        {
            get
            {
                return this.redirectUriField;
            }
            set
            {
                this.redirectUriField = value;
                this.RaisePropertyChanged("redirectUri");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string scope
        {
            get
            {
                return this.scopeField;
            }
            set
            {
                this.scopeField = value;
                this.RaisePropertyChanged("scope");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
                this.RaisePropertyChanged("state");
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RefreshAccessTokenRequestType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AccessTokenRequestType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AuthorizationRequestType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public abstract partial class OAuthRequestAbstractType : object, System.ComponentModel.INotifyPropertyChanged
    {

        private OauthHeaderType[] oauthHeadersField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oauthHeaders", Order = 0)]
        public OauthHeaderType[] oauthHeaders
        {
            get
            {
                return this.oauthHeadersField;
            }
            set
            {
                this.oauthHeadersField = value;
                this.RaisePropertyChanged("oauthHeaders");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public abstract partial class OauthHeaderType : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
                this.RaisePropertyChanged("value");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public abstract partial class OauthAttributeType : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
                this.RaisePropertyChanged("value");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AccessTokenResponseType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AuthorizationResponseType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public abstract partial class OAuthResponseAbstractType : object, System.ComponentModel.INotifyPropertyChanged
    {

        private OauthHeaderType[] oauthHeadersField;

        private string statusCodeField;

        private ErrorCodeType errorField;

        private bool errorFieldSpecified;

        private string error_descriptionField;

        private string error_uriField;

        private string stateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oauthHeaders", Order = 0)]
        public OauthHeaderType[] oauthHeaders
        {
            get
            {
                return this.oauthHeadersField;
            }
            set
            {
                this.oauthHeadersField = value;
                this.RaisePropertyChanged("oauthHeaders");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string statusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
                this.RaisePropertyChanged("statusCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ErrorCodeType error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
                this.RaisePropertyChanged("error");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool errorSpecified
        {
            get
            {
                return this.errorFieldSpecified;
            }
            set
            {
                this.errorFieldSpecified = value;
                this.RaisePropertyChanged("errorSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string error_description
        {
            get
            {
                return this.error_descriptionField;
            }
            set
            {
                this.error_descriptionField = value;
                this.RaisePropertyChanged("error_description");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string error_uri
        {
            get
            {
                return this.error_uriField;
            }
            set
            {
                this.error_uriField = value;
                this.RaisePropertyChanged("error_uri");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
                this.RaisePropertyChanged("state");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public enum ErrorCodeType
    {

        /// <remarks/>
        invalid_request,

        /// <remarks/>
        unauthorized_client,

        /// <remarks/>
        access_denied,

        /// <remarks/>
        unsupported_response_type,

        /// <remarks/>
        invalid_scope,

        /// <remarks/>
        server_error,

        /// <remarks/>
        temporary_unavailable,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public partial class AccessTokenResponseType : OAuthResponseAbstractType
    {

        private OauthAttributeType[] oauthAttributesField;

        private string tokeyTypeField;

        private string accessTokenField;

        private string expiresInField;

        private string refreshTokenField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("oauthAttributes", Order = 0)]
        public OauthAttributeType[] oauthAttributes
        {
            get
            {
                return this.oauthAttributesField;
            }
            set
            {
                this.oauthAttributesField = value;
                this.RaisePropertyChanged("oauthAttributes");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tokeyType
        {
            get
            {
                return this.tokeyTypeField;
            }
            set
            {
                this.tokeyTypeField = value;
                this.RaisePropertyChanged("tokeyType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string accessToken
        {
            get
            {
                return this.accessTokenField;
            }
            set
            {
                this.accessTokenField = value;
                this.RaisePropertyChanged("accessToken");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string expiresIn
        {
            get
            {
                return this.expiresInField;
            }
            set
            {
                this.expiresInField = value;
                this.RaisePropertyChanged("expiresIn");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string refreshToken
        {
            get
            {
                return this.refreshTokenField;
            }
            set
            {
                this.refreshTokenField = value;
                this.RaisePropertyChanged("refreshToken");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public partial class AuthorizationResponseType : OAuthResponseAbstractType
    {

        private string codeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
                this.RaisePropertyChanged("code");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public partial class RefreshAccessTokenRequestType : OAuthRequestAbstractType
    {

        private string grantTypeField;

        private string scopeField;

        private string refreshTokenField;

        private string clientIdField;

        private string clientSecretField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string grantType
        {
            get
            {
                return this.grantTypeField;
            }
            set
            {
                this.grantTypeField = value;
                this.RaisePropertyChanged("grantType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string scope
        {
            get
            {
                return this.scopeField;
            }
            set
            {
                this.scopeField = value;
                this.RaisePropertyChanged("scope");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string refreshToken
        {
            get
            {
                return this.refreshTokenField;
            }
            set
            {
                this.refreshTokenField = value;
                this.RaisePropertyChanged("refreshToken");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string clientId
        {
            get
            {
                return this.clientIdField;
            }
            set
            {
                this.clientIdField = value;
                this.RaisePropertyChanged("clientId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string clientSecret
        {
            get
            {
                return this.clientSecretField;
            }
            set
            {
                this.clientSecretField = value;
                this.RaisePropertyChanged("clientSecret");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol")]
    public partial class AccessTokenRequestType : OAuthRequestAbstractType
    {

        private string grantTypeField;

        private string clientIdField;

        private string clientSecretField;

        private string usernameField;

        private string passwordField;

        private string scopeField;

        private string redirectUriField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string grantType
        {
            get
            {
                return this.grantTypeField;
            }
            set
            {
                this.grantTypeField = value;
                this.RaisePropertyChanged("grantType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string clientId
        {
            get
            {
                return this.clientIdField;
            }
            set
            {
                this.clientIdField = value;
                this.RaisePropertyChanged("clientId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string clientSecret
        {
            get
            {
                return this.clientSecretField;
            }
            set
            {
                this.clientSecretField = value;
                this.RaisePropertyChanged("clientSecret");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
                this.RaisePropertyChanged("username");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
                this.RaisePropertyChanged("password");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string scope
        {
            get
            {
                return this.scopeField;
            }
            set
            {
                this.scopeField = value;
                this.RaisePropertyChanged("scope");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string redirectUri
        {
            get
            {
                return this.redirectUriField;
            }
            set
            {
                this.redirectUriField = value;
                this.RaisePropertyChanged("redirectUri");
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AuthorizationRequestInput
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol", Order = 0)]
        public OAuth2Protocol.AccessTokenRequestor.AuthorizationRequestType AuthorizationRequest;

        public AuthorizationRequestInput()
        {
        }

        public AuthorizationRequestInput(OAuth2Protocol.AccessTokenRequestor.AuthorizationRequestType AuthorizationRequest)
        {
            this.AuthorizationRequest = AuthorizationRequest;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AuthorizationResponseOutput
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol", Order = 0)]
        public OAuth2Protocol.AccessTokenRequestor.AuthorizationResponseType AuthorizationResponse;

        public AuthorizationResponseOutput()
        {
        }

        public AuthorizationResponseOutput(OAuth2Protocol.AccessTokenRequestor.AuthorizationResponseType AuthorizationResponse)
        {
            this.AuthorizationResponse = AuthorizationResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AccessTokenRequestInput
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol", Order = 0)]
        public OAuth2Protocol.AccessTokenRequestor.AccessTokenRequestType AccessTokenRequest;

        public AccessTokenRequestInput()
        {
        }

        public AccessTokenRequestInput(OAuth2Protocol.AccessTokenRequestor.AccessTokenRequestType AccessTokenRequest)
        {
            this.AccessTokenRequest = AccessTokenRequest;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AccessTokenResponseOutput
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "urn:org:atricore:idbus:common:oauth:2.0:protocol", Order = 0)]
        public OAuth2Protocol.AccessTokenRequestor.AccessTokenResponseType AccessTokenResponse;

        public AccessTokenResponseOutput()
        {
        }

        public AccessTokenResponseOutput(OAuth2Protocol.AccessTokenRequestor.AccessTokenResponseType AccessTokenResponse)
        {
            this.AccessTokenResponse = AccessTokenResponse;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OAuthPortTypeChannel : OAuth2Protocol.AccessTokenRequestor.OAuthPortType, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OAuthPortTypeClient : System.ServiceModel.ClientBase<OAuth2Protocol.AccessTokenRequestor.OAuthPortType>, OAuth2Protocol.AccessTokenRequestor.OAuthPortType
    {

        public OAuthPortTypeClient()
        {
        }

        public OAuthPortTypeClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public OAuthPortTypeClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public OAuthPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public OAuthPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OAuth2Protocol.AccessTokenRequestor.AuthorizationResponseOutput OAuth2Protocol.AccessTokenRequestor.OAuthPortType.AuthorizationRequest(OAuth2Protocol.AccessTokenRequestor.AuthorizationRequestInput request)
        {
            return base.Channel.AuthorizationRequest(request);
        }

        public OAuth2Protocol.AccessTokenRequestor.AuthorizationResponseType AuthorizationRequest(OAuth2Protocol.AccessTokenRequestor.AuthorizationRequestType AuthorizationRequest1)
        {
            OAuth2Protocol.AccessTokenRequestor.AuthorizationRequestInput inValue = new OAuth2Protocol.AccessTokenRequestor.AuthorizationRequestInput();
            inValue.AuthorizationRequest = AuthorizationRequest1;
            OAuth2Protocol.AccessTokenRequestor.AuthorizationResponseOutput retVal = ((OAuth2Protocol.AccessTokenRequestor.OAuthPortType)(this)).AuthorizationRequest(inValue);
            return retVal.AuthorizationResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OAuth2Protocol.AccessTokenRequestor.AccessTokenResponseOutput OAuth2Protocol.AccessTokenRequestor.OAuthPortType.AccessTokenRequest(OAuth2Protocol.AccessTokenRequestor.AccessTokenRequestInput request)
        {
            return base.Channel.AccessTokenRequest(request);
        }

        public OAuth2Protocol.AccessTokenRequestor.AccessTokenResponseType AccessTokenRequest(OAuth2Protocol.AccessTokenRequestor.AccessTokenRequestType AccessTokenRequest1)
        {
            OAuth2Protocol.AccessTokenRequestor.AccessTokenRequestInput inValue = new OAuth2Protocol.AccessTokenRequestor.AccessTokenRequestInput();
            inValue.AccessTokenRequest = AccessTokenRequest1;
            OAuth2Protocol.AccessTokenRequestor.AccessTokenResponseOutput retVal = ((OAuth2Protocol.AccessTokenRequestor.OAuthPortType)(this)).AccessTokenRequest(inValue);
            return retVal.AccessTokenResponse;
        }
    }
}
