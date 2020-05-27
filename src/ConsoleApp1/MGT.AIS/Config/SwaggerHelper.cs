using NSwag;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGT.AIS
{
    public class SwaggerHelper : IOperationProcessor
    {
        public Task<bool> ProcessAsync(OperationProcessorContext context)
        {
            context.OperationDescription.Operation.Parameters.Add(
            new SwaggerParameter
            {
                Name = "token",
                Kind = SwaggerParameterKind.Header,
                Type = NJsonSchema.JsonObjectType.String,
                IsRequired = false,
                Description = "Chave de acesso à API, fornecida pela RevendaCliente",
                Default = "Default Value"
            });

            return Task.FromResult(true);
        }
    }
}
