using Microsoft.VisualStudio.DebuggerVisualizers;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(NetFabric.AngleDebuggerVisualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(NetFabric.Angle),
    Description = "Angle Visualizer")
]

namespace NetFabric
{
    public class AngleDebuggerVisualizer
        : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var angle = (Angle)objectProvider.GetObject();
            var form = new AngleVisualizerForm(angle);
            windowService.ShowDialog(form);
        }
    }
}
