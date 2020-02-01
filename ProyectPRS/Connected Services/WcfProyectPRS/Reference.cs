//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//     //
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace WcfProyectPRS
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseGeneric", Namespace="http://schemas.datacontract.org/2004/07/BusinessLogic")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WcfProyectPRS.ResponseJson))]
    public partial class ResponseGeneric : object
    {
        
        private int CodeField;
        
        private string MessageField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Code
        {
            get
            {
                return this.CodeField;
            }
            set
            {
                this.CodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseJson", Namespace="http://schemas.datacontract.org/2004/07/BusinessLogic")]
    public partial class ResponseJson : WcfProyectPRS.ResponseGeneric
    {
        
        private string JsonField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Json
        {
            get
            {
                return this.JsonField;
            }
            set
            {
                this.JsonField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfProyectPRS.IInitialize")]
    public interface IInitialize
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInitialize/CheckRoundMoves", ReplyAction="http://tempuri.org/IInitialize/CheckRoundMovesResponse")]
        System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> CheckRoundMovesAsync(int idGame, int idRound);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInitialize/NewGame", ReplyAction="http://tempuri.org/IInitialize/NewGameResponse")]
        System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> NewGameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInitialize/GetGameDetailScore", ReplyAction="http://tempuri.org/IInitialize/GetGameDetailScoreResponse")]
        System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> GetGameDetailScoreAsync(int idPlayer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInitialize/GetGamePlayersMove", ReplyAction="http://tempuri.org/IInitialize/GetGamePlayersMoveResponse")]
        System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> GetGamePlayersMoveAsync(int idGame);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInitialize/GetMoves", ReplyAction="http://tempuri.org/IInitialize/GetMovesResponse")]
        System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> GetMovesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInitialize/NewMove", ReplyAction="http://tempuri.org/IInitialize/NewMoveResponse")]
        System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> NewMoveAsync(int idGame, int idMove, int idPlayer, int idRound);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInitialize/NewPlayer", ReplyAction="http://tempuri.org/IInitialize/NewPlayerResponse")]
        System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> NewPlayerAsync(string player, int idPlayer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInitialize/GetPlayersGame", ReplyAction="http://tempuri.org/IInitialize/GetPlayersGameResponse")]
        System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> GetPlayersGameAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface IInitializeChannel : WcfProyectPRS.IInitialize, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class InitializeClient : System.ServiceModel.ClientBase<WcfProyectPRS.IInitialize>, WcfProyectPRS.IInitialize
    {
        
    /// <summary>
    /// Implemente este método parcial para configurar el punto de conexión de servicio.
    /// </summary>
    /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
    /// <param name="clientCredentials">Credenciales de cliente</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public InitializeClient(EndpointConfiguration endpointConfiguration) : 
                base(InitializeClient.GetBindingForEndpoint(endpointConfiguration), InitializeClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InitializeClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(InitializeClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InitializeClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(InitializeClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InitializeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> CheckRoundMovesAsync(int idGame, int idRound)
        {
            return base.Channel.CheckRoundMovesAsync(idGame, idRound);
        }
        
        public System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> NewGameAsync()
        {
            return base.Channel.NewGameAsync();
        }
        
        public System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> GetGameDetailScoreAsync(int idPlayer)
        {
            return base.Channel.GetGameDetailScoreAsync(idPlayer);
        }
        
        public System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> GetGamePlayersMoveAsync(int idGame)
        {
            return base.Channel.GetGamePlayersMoveAsync(idGame);
        }
        
        public System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> GetMovesAsync()
        {
            return base.Channel.GetMovesAsync();
        }
        
        public System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> NewMoveAsync(int idGame, int idMove, int idPlayer, int idRound)
        {
            return base.Channel.NewMoveAsync(idGame, idMove, idPlayer, idRound);
        }
        
        public System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> NewPlayerAsync(string player, int idPlayer)
        {
            return base.Channel.NewPlayerAsync(player, idPlayer);
        }
        
        public System.Threading.Tasks.Task<WcfProyectPRS.ResponseJson> GetPlayersGameAsync()
        {
            return base.Channel.GetPlayersGameAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IInitialize))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpsBinding_IInitialize))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IInitialize))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost/WcfProyectoPRS/Initialize.svc");
            }
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpsBinding_IInitialize))
            {
                return new System.ServiceModel.EndpointAddress("https://desktop-46vv2t7/WcfProyectoPRS/Initialize.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IInitialize,
            
            BasicHttpsBinding_IInitialize,
        }
    }
}
