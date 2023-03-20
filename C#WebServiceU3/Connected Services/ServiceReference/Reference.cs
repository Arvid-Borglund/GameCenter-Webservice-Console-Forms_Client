﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationGameCenter.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="KeyValuePairOfStringString", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class KeyValuePairOfStringString : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.WebServiceGameCenterSoap")]
    public interface WebServiceGameCenterSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerifyCredentials", ReplyAction="*")]
        WebApplicationGameCenter.ServiceReference.VerifyCredentialsResponse VerifyCredentials(WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerifyCredentials", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.VerifyCredentialsResponse> VerifyCredentialsAsync(WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequest request);
        
        // CODEGEN: Generating message contract since element name selectedEntityCon from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSelectedEntityData", ReplyAction="*")]
        WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataResponse GetSelectedEntityData(WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSelectedEntityData", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataResponse> GetSelectedEntityDataAsync(WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequest request);
        
        // CODEGEN: Generating message contract since element name entityData from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        WebApplicationGameCenter.ServiceReference.CreateResponse Create(WebApplicationGameCenter.ServiceReference.CreateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Create", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.CreateResponse> CreateAsync(WebApplicationGameCenter.ServiceReference.CreateRequest request);
        
        // CODEGEN: Generating message contract since element name idDelete from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        WebApplicationGameCenter.ServiceReference.DeleteResponse Delete(WebApplicationGameCenter.ServiceReference.DeleteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.DeleteResponse> DeleteAsync(WebApplicationGameCenter.ServiceReference.DeleteRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class VerifyCredentialsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="VerifyCredentials", Namespace="http://tempuri.org/", Order=0)]
        public WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequestBody Body;
        
        public VerifyCredentialsRequest() {
        }
        
        public VerifyCredentialsRequest(WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class VerifyCredentialsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string id;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string loginPassword;
        
        public VerifyCredentialsRequestBody() {
        }
        
        public VerifyCredentialsRequestBody(string id, string loginPassword) {
            this.id = id;
            this.loginPassword = loginPassword;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class VerifyCredentialsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="VerifyCredentialsResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplicationGameCenter.ServiceReference.VerifyCredentialsResponseBody Body;
        
        public VerifyCredentialsResponse() {
        }
        
        public VerifyCredentialsResponse(WebApplicationGameCenter.ServiceReference.VerifyCredentialsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class VerifyCredentialsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool VerifyCredentialsResult;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string role;
        
        public VerifyCredentialsResponseBody() {
        }
        
        public VerifyCredentialsResponseBody(bool VerifyCredentialsResult, string role) {
            this.VerifyCredentialsResult = VerifyCredentialsResult;
            this.role = role;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSelectedEntityDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetSelectedEntityData", Namespace="http://tempuri.org/", Order=0)]
        public WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequestBody Body;
        
        public GetSelectedEntityDataRequest() {
        }
        
        public GetSelectedEntityDataRequest(WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetSelectedEntityDataRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string selectedEntityCon;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string role;
        
        public GetSelectedEntityDataRequestBody() {
        }
        
        public GetSelectedEntityDataRequestBody(string selectedEntityCon, string role) {
            this.selectedEntityCon = selectedEntityCon;
            this.role = role;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetSelectedEntityDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetSelectedEntityDataResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataResponseBody Body;
        
        public GetSelectedEntityDataResponse() {
        }
        
        public GetSelectedEntityDataResponse(WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetSelectedEntityDataResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetSelectedEntityDataResult;
        
        public GetSelectedEntityDataResponseBody() {
        }
        
        public GetSelectedEntityDataResponseBody(string GetSelectedEntityDataResult) {
            this.GetSelectedEntityDataResult = GetSelectedEntityDataResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Create", Namespace="http://tempuri.org/", Order=0)]
        public WebApplicationGameCenter.ServiceReference.CreateRequestBody Body;
        
        public CreateRequest() {
        }
        
        public CreateRequest(WebApplicationGameCenter.ServiceReference.CreateRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CreateRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WebApplicationGameCenter.ServiceReference.KeyValuePairOfStringString[] entityData;
        
        public CreateRequestBody() {
        }
        
        public CreateRequestBody(WebApplicationGameCenter.ServiceReference.KeyValuePairOfStringString[] entityData) {
            this.entityData = entityData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CreateResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplicationGameCenter.ServiceReference.CreateResponseBody Body;
        
        public CreateResponse() {
        }
        
        public CreateResponse(WebApplicationGameCenter.ServiceReference.CreateResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CreateResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool CreateResult;
        
        public CreateResponseBody() {
        }
        
        public CreateResponseBody(bool CreateResult) {
            this.CreateResult = CreateResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Delete", Namespace="http://tempuri.org/", Order=0)]
        public WebApplicationGameCenter.ServiceReference.DeleteRequestBody Body;
        
        public DeleteRequest() {
        }
        
        public DeleteRequest(WebApplicationGameCenter.ServiceReference.DeleteRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class DeleteRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string idDelete;
        
        public DeleteRequestBody() {
        }
        
        public DeleteRequestBody(string idDelete) {
            this.idDelete = idDelete;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DeleteResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplicationGameCenter.ServiceReference.DeleteResponseBody Body;
        
        public DeleteResponse() {
        }
        
        public DeleteResponse(WebApplicationGameCenter.ServiceReference.DeleteResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class DeleteResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool DeleteResult;
        
        public DeleteResponseBody() {
        }
        
        public DeleteResponseBody(bool DeleteResult) {
            this.DeleteResult = DeleteResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceGameCenterSoapChannel : WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceGameCenterSoapClient : System.ServiceModel.ClientBase<WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap>, WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap {
        
        public WebServiceGameCenterSoapClient() {
        }
        
        public WebServiceGameCenterSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceGameCenterSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceGameCenterSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceGameCenterSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplicationGameCenter.ServiceReference.VerifyCredentialsResponse WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap.VerifyCredentials(WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequest request) {
            return base.Channel.VerifyCredentials(request);
        }
        
        public bool VerifyCredentials(string id, string loginPassword, out string role) {
            WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequest inValue = new WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequest();
            inValue.Body = new WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequestBody();
            inValue.Body.id = id;
            inValue.Body.loginPassword = loginPassword;
            WebApplicationGameCenter.ServiceReference.VerifyCredentialsResponse retVal = ((WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap)(this)).VerifyCredentials(inValue);
            role = retVal.Body.role;
            return retVal.Body.VerifyCredentialsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.VerifyCredentialsResponse> WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap.VerifyCredentialsAsync(WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequest request) {
            return base.Channel.VerifyCredentialsAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.VerifyCredentialsResponse> VerifyCredentialsAsync(string id, string loginPassword) {
            WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequest inValue = new WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequest();
            inValue.Body = new WebApplicationGameCenter.ServiceReference.VerifyCredentialsRequestBody();
            inValue.Body.id = id;
            inValue.Body.loginPassword = loginPassword;
            return ((WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap)(this)).VerifyCredentialsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataResponse WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap.GetSelectedEntityData(WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequest request) {
            return base.Channel.GetSelectedEntityData(request);
        }
        
        public string GetSelectedEntityData(string selectedEntityCon, string role) {
            WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequest inValue = new WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequest();
            inValue.Body = new WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequestBody();
            inValue.Body.selectedEntityCon = selectedEntityCon;
            inValue.Body.role = role;
            WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataResponse retVal = ((WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap)(this)).GetSelectedEntityData(inValue);
            return retVal.Body.GetSelectedEntityDataResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataResponse> WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap.GetSelectedEntityDataAsync(WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequest request) {
            return base.Channel.GetSelectedEntityDataAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataResponse> GetSelectedEntityDataAsync(string selectedEntityCon, string role) {
            WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequest inValue = new WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequest();
            inValue.Body = new WebApplicationGameCenter.ServiceReference.GetSelectedEntityDataRequestBody();
            inValue.Body.selectedEntityCon = selectedEntityCon;
            inValue.Body.role = role;
            return ((WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap)(this)).GetSelectedEntityDataAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplicationGameCenter.ServiceReference.CreateResponse WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap.Create(WebApplicationGameCenter.ServiceReference.CreateRequest request) {
            return base.Channel.Create(request);
        }
        
        public bool Create(WebApplicationGameCenter.ServiceReference.KeyValuePairOfStringString[] entityData) {
            WebApplicationGameCenter.ServiceReference.CreateRequest inValue = new WebApplicationGameCenter.ServiceReference.CreateRequest();
            inValue.Body = new WebApplicationGameCenter.ServiceReference.CreateRequestBody();
            inValue.Body.entityData = entityData;
            WebApplicationGameCenter.ServiceReference.CreateResponse retVal = ((WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap)(this)).Create(inValue);
            return retVal.Body.CreateResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.CreateResponse> WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap.CreateAsync(WebApplicationGameCenter.ServiceReference.CreateRequest request) {
            return base.Channel.CreateAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.CreateResponse> CreateAsync(WebApplicationGameCenter.ServiceReference.KeyValuePairOfStringString[] entityData) {
            WebApplicationGameCenter.ServiceReference.CreateRequest inValue = new WebApplicationGameCenter.ServiceReference.CreateRequest();
            inValue.Body = new WebApplicationGameCenter.ServiceReference.CreateRequestBody();
            inValue.Body.entityData = entityData;
            return ((WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap)(this)).CreateAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplicationGameCenter.ServiceReference.DeleteResponse WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap.Delete(WebApplicationGameCenter.ServiceReference.DeleteRequest request) {
            return base.Channel.Delete(request);
        }
        
        public bool Delete(string idDelete) {
            WebApplicationGameCenter.ServiceReference.DeleteRequest inValue = new WebApplicationGameCenter.ServiceReference.DeleteRequest();
            inValue.Body = new WebApplicationGameCenter.ServiceReference.DeleteRequestBody();
            inValue.Body.idDelete = idDelete;
            WebApplicationGameCenter.ServiceReference.DeleteResponse retVal = ((WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap)(this)).Delete(inValue);
            return retVal.Body.DeleteResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.DeleteResponse> WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap.DeleteAsync(WebApplicationGameCenter.ServiceReference.DeleteRequest request) {
            return base.Channel.DeleteAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplicationGameCenter.ServiceReference.DeleteResponse> DeleteAsync(string idDelete) {
            WebApplicationGameCenter.ServiceReference.DeleteRequest inValue = new WebApplicationGameCenter.ServiceReference.DeleteRequest();
            inValue.Body = new WebApplicationGameCenter.ServiceReference.DeleteRequestBody();
            inValue.Body.idDelete = idDelete;
            return ((WebApplicationGameCenter.ServiceReference.WebServiceGameCenterSoap)(this)).DeleteAsync(inValue);
        }
    }
}
