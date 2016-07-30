namespace WcfService
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.ServiceModel;
    using Code;

    [ServiceContract(Namespace = "http://schemas.datacontract.org/2004/07/Contract.DTOs")]
    [ServiceKnownType(nameof(GetKnownTypes))]
    public class CommandService
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider) =>
            Bootstrapper.GetCommandTypes();

        [OperationContract]
        [FaultContract(typeof(ValidationError))]
        public void Execute(dynamic command)
        {
            try
            {
                dynamic commandHandler = Bootstrapper.GetCommandHandler(command.GetType());

                commandHandler.Handle(command);
            }
            catch (Exception ex)
            {
                Bootstrapper.Log(ex);

                var faultException = WcfExceptionTranslator.CreateFaultExceptionOrNull(ex);

                if (faultException != null)
                {
                    throw faultException;
                }

                throw;
            }
        }
    }
}