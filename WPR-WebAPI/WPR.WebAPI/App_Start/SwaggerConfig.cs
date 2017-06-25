using System.Web.Http;
using WebActivatorEx;
using PartnerView.WebAPI;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Collections.Generic;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace PartnerView.WebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "PartnerView.WebAPI");
                        c.BasicAuth("basic")
                            .Description("Basic HTTP Authentication");

                        c.ApiKey("apiKey")
                            .Description("API Key Authentication")
                            .Name("apiKey")
                            .In("header");
                        c.UseFullTypeNameInSchemaIds();
                        c.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
                    })
                .EnableSwaggerUi(c => { });
        }

        public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                if (operation.operationId == "User_LoginUser")
                {
                    operation.parameters[0].description = "Enter UserName, Password";
                }
                else
                {
                    if (operation.parameters == null) operation.parameters = new List<Parameter>();
                    operation.parameters.Add(new Parameter
                    {
                        name = "Authorization",
                        @in = "header",
                        description = "Authorization-Token",
                        required = true,
                        type = "string"
                    });
                }


            }
        }


    }
}