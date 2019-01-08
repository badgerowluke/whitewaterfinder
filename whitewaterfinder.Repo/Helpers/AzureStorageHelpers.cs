using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
namespace whitewaterfinder.Repo.Helpers
{
    internal static class AzureFormatHelpers
    {
        public static T RecastEntity<T>(DynamicTableEntity entity)
        {
            var outVal = (T)Activator.CreateInstance(typeof(T));
            var content = outVal.GetType().GetGenericArguments()[0];            
            var outContent = Activator.CreateInstance(content);
            
            foreach(var property in entity.Properties)
            {
                var propInfo = outContent.GetType().GetProperty(property.Key);
                if(propInfo != null)
                {
                    switch(propInfo.PropertyType.ToString())
                    {
                        case ("System.String"):
                            outContent.GetType().GetProperty(property.Key)
                                .SetValue(outContent, property.Value.StringValue);
                            break;
                        case ("System.DateTime"):
                            outContent.GetType().GetProperty(property.Key)
                                .SetValue(outContent, property.Value.DateTime);
                            break;
                        case("Systme.Int32"):
                            outContent.GetType().GetProperty(property.Key)
                                .SetValue(outContent, property.Value.DateTime);
                            break;
                        case("Systme.Double"):
                            outContent.GetType().GetProperty(property.Key)
                                .SetValue(outContent, property.Value.DateTime);
                            break;        
                        case("Systme.Boolean"):
                            outContent.GetType().GetProperty(property.Key)
                                .SetValue(outContent, property.Value.DateTime);
                            break;                                                                
                            
                    }
                }

            }
            return (T) outContent;
        }
        public static T RecastEntities<T>(IEnumerable<DynamicTableEntity> entities)
        {
            var outVal = (T)Activator.CreateInstance(typeof(T));
            var content = outVal.GetType().GetGenericArguments()[0];
            foreach(var entity in entities)
            {
                var outContent = Activator.CreateInstance(content);
                
                foreach(var property in entity.Properties)
                {
                    var propInfo = outContent.GetType().GetProperty(property.Key);
                    if(propInfo != null)
                    {
                        switch(propInfo.PropertyType.ToString())
                        {
                            case ("System.String"):
                                outContent.GetType().GetProperty(property.Key)
                                    .SetValue(outContent, property.Value.StringValue);
                                break;
                            case ("System.DateTime"):
                                outContent.GetType().GetProperty(property.Key)
                                    .SetValue(outContent, property.Value.DateTime);
                                break;
                            case("Systme.Int32"):
                                outContent.GetType().GetProperty(property.Key)
                                    .SetValue(outContent, property.Value.DateTime);
                                break;
                            case("Systme.Double"):
                                outContent.GetType().GetProperty(property.Key)
                                    .SetValue(outContent, property.Value.DateTime);
                                break;        
                            case("Systme.Boolean"):
                                outContent.GetType().GetProperty(property.Key)
                                    .SetValue(outContent, property.Value.DateTime);
                                break;                                                                
                                
                        }
                    }

                }
                outVal.GetType().GetMethod("Add").Invoke(outVal, new[] { outContent });

            }
            return outVal;
        }
    }
}