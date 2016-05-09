using System.Windows.Forms;

namespace NetFabric
{
    public partial class AngleVisualizerForm 
        : Form
    {
        public AngleVisualizerForm(Angle angle)
        {
            InitializeComponent();

            labelValueRadians.Text = angle.ToString("R3") + " rad";
            labelValueDegrees.Text = angle.ToString("D3") + "°";
            labelValueDegreesMinutes.Text = angle.ToString("M3");
            labelValueDegreesMinutesSeconds.Text = angle.ToString("S3");
            labelValueGradians.Text = angle.ToString("G3") + " grad";

            var reduced = Angle.Reduce(angle);
            labelReducedRadians.Text = reduced.ToString("R3") + " rad";
            labelReducedDegrees.Text = reduced.ToString("D3") + "°";
            labelReducedDegreesMinutes.Text = reduced.ToString("M3");
            labelReducedDegreesMinutesSeconds.Text = reduced.ToString("S3");
            labelReducedGradians.Text = reduced.ToString("G3") + " grad";

            var reference = Angle.GetReference(angle);
            labelReferenceRadians.Text = reference.ToString("R3") + " rad";
            labelReferenceDegrees.Text = reference.ToString("D3") + "°";
            labelReferenceDegreesMinutes.Text = reference.ToString("M3");
            labelReferenceDegreesMinutesSeconds.Text = reference.ToString("S3");
            labelReferenceGradians.Text = reference.ToString("G3") + " grad";
        }
    }
}
