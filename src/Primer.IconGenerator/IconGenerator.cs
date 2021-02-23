using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.CodeAnalysis;

namespace Primer.IconGenerator
{
    /// <summary>
    /// The icon generator
    /// </summary>
    [Generator]
    class IconGenerator : ISourceGenerator
    {
        /// <summary>
        /// Initializes the generator
        /// </summary>
        /// <param name="context">The initialization context</param>
        public void Initialize(GeneratorInitializationContext context) { }

        /// <summary>
        /// Executes the source generator
        /// </summary>
        /// <param name="context">The generator context</param>
        public void Execute(GeneratorExecutionContext context)
        {
            foreach (AdditionalText file in context.AdditionalFiles)
            {
                if (Path.GetFileName(file.Path).Equals("icons.json"))
                {
                    var json = JsonDocument.Parse(file.GetText().ToString());

                    foreach (var icon in json.RootElement.EnumerateObject())
                    {
                        context.AddSource(icon.Name.ToPascalCase() + ".cs", ProcessIcon(icon.Value));
                    }
                }
            }
        }

        /// <summary>
        /// Processes an icon
        /// </summary>
        /// <param name="json">The icon json</param>
        /// <returns>The icon source string</returns>
        private string ProcessIcon(JsonElement json)
        {
            var sourceBuilder = new StringBuilder();

            // Usings
            sourceBuilder.AppendLine("using System;");
            sourceBuilder.AppendLine("using Microsoft.AspNetCore.Components;");
            sourceBuilder.AppendLine("using Microsoft.AspNetCore.Components.Rendering;");
            sourceBuilder.AppendLine("using Primer.Components.Base;");
            sourceBuilder.AppendLine("");

            // Start of namespace
            sourceBuilder.AppendLine("namespace Primer.Components");
            sourceBuilder.AppendLine("{");

            // Start of class
            sourceBuilder.AppendLine("    /// <summary>");
            sourceBuilder.AppendLine($"    /// Primer {json.GetProperty("name").GetString().Replace("-", " ")} icon");
            sourceBuilder.AppendLine("    /// </summary>");
            sourceBuilder.AppendLine($"    public class Primer{json.GetProperty("name").GetString().ToPascalCase()}Icon : PrimerComponentBase");
            sourceBuilder.AppendLine("    {");

            // Size parameter
            sourceBuilder.AppendLine("        /// <summary>");
            sourceBuilder.AppendLine("        /// The size of the icon");
            sourceBuilder.AppendLine("        /// </summary>");
            sourceBuilder.AppendLine("        [Parameter]");
            sourceBuilder.AppendLine("        public int Size { get; set; } = 16;");
            sourceBuilder.AppendLine("");

            // Start of BuildRenderTree
            sourceBuilder.AppendLine("        /// <summary>");
            sourceBuilder.AppendLine("        /// Builds the render tree for the icon");
            sourceBuilder.AppendLine("        /// </summary>");
            sourceBuilder.AppendLine("        /// <param name=\"builder\">The tree builder</param>");
            sourceBuilder.AppendLine("        protected override void BuildRenderTree(RenderTreeBuilder builder)");
            sourceBuilder.AppendLine("        {");

            // Start of if visible
            sourceBuilder.AppendLine("            if (Visible)");
            sourceBuilder.AppendLine("            {");

            foreach (var size in json.GetProperty("heights").EnumerateObject())
            {
                // Start of size check
                sourceBuilder.AppendLine($"                if (Size == {size.Name})");
                sourceBuilder.AppendLine("                {");

                // Icon content
                sourceBuilder.AppendLine("                    builder.OpenElement(0, \"svg\");");
                sourceBuilder.AppendLine("                    builder.AddAttribute(1, \"class\", ClassGenerator.Class);");
                sourceBuilder.AppendLine("                    builder.AddAttribute(2, \"xmlns\", \"http://www.w3.org/2000/svg\");");
                sourceBuilder.AppendLine($"                    builder.AddAttribute(3, \"viewBox\", \"0 0 {size.Value.GetProperty("width").GetInt32()} {size.Name}\");");
                sourceBuilder.AppendLine($"                    builder.AddAttribute(4, \"width\", \"{size.Value.GetProperty("width").GetInt32()}\");");
                sourceBuilder.AppendLine($"                    builder.AddAttribute(5, \"height\", \"{size.Name}\");");
                sourceBuilder.AppendLine($"                    builder.AddMarkupContent(6, {size.Value.GetProperty("path").GetRawText()});");
                sourceBuilder.AppendLine("                    builder.CloseElement();");

                // End of size check
                sourceBuilder.AppendLine("                }");
            }

            //End of if visible
            sourceBuilder.AppendLine("            }");

            // End of BuildRenderTree
            sourceBuilder.AppendLine("        }");
            sourceBuilder.AppendLine("");

            // Start of OnInitialized
            sourceBuilder.AppendLine("        /// <summary>");
            sourceBuilder.AppendLine("        /// Occurs when the icon is initializing");
            sourceBuilder.AppendLine("        /// </summary>");
            sourceBuilder.AppendLine("        protected override void OnInitialized()");
            sourceBuilder.AppendLine("        {");

            sourceBuilder.AppendLine($"            ClassGenerator.Add(\"octicon\").Add(\"octicon-{json.GetProperty("name")}\");");

            // End of OnInitialized
            sourceBuilder.AppendLine("        }");

            // End of class
            sourceBuilder.AppendLine("    }");

            // End of namespace
            sourceBuilder.AppendLine("}");

            return sourceBuilder.ToString();
        }
    }
}
