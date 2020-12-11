using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OxyPlotTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var model = new PlotModel
            {
                Title = "OxyPlot 그래프 테스트",
                PlotType = PlotType.XY,
            };

            // 차트에 표현해줄 데이터 입니다.
            Dictionary<DateTime, double> data = new Dictionary<DateTime, double>();
            data.Add(new DateTime(2020, 12, 1, 0, 00, 00), 10);
            data.Add(new DateTime(2020, 12, 2, 0, 00, 00), 20);
            data.Add(new DateTime(2020, 12, 3, 0, 00, 00), 30);
            data.Add(new DateTime(2020, 12, 4, 0, 00, 00), 40);
            data.Add(new DateTime(2020, 12, 5, 0, 00, 00), 50);
            data.Add(new DateTime(2020, 12, 6, 0, 00, 00), 10);
            data.Add(new DateTime(2020, 12, 7, 0, 00, 00), 20);
            data.Add(new DateTime(2020, 12, 8, 0, 00, 00), 30);
            data.Add(new DateTime(2020, 12, 9, 0, 00, 00), 40);
            data.Add(new DateTime(2020, 12, 10, 0, 00, 00), 50);

            CreateBarChart(model, data);

            data = new Dictionary<DateTime, double>();
            data.Add(new DateTime(2020, 12, 1, 0, 00, 00), 50);
            data.Add(new DateTime(2020, 12, 2, 0, 00, 00), 60);
            data.Add(new DateTime(2020, 12, 3, 0, 00, 00), 70);
            data.Add(new DateTime(2020, 12, 4, 0, 00, 00), 80);
            data.Add(new DateTime(2020, 12, 5, 0, 00, 00), 70);
            data.Add(new DateTime(2020, 12, 6, 0, 00, 00), 80);
            data.Add(new DateTime(2020, 12, 7, 0, 00, 00), 90);
            data.Add(new DateTime(2020, 12, 8, 0, 00, 00), 50);
            data.Add(new DateTime(2020, 12, 9, 0, 00, 00), 40);
            data.Add(new DateTime(2020, 12, 10, 0, 00, 00), 10);

            CreateBarChart(model, data);


            // x축은 시간이 보이도록 설정합니다.
            model.Axes.Add(new DateTimeAxis
            {
                Title = "일",
                Position = AxisPosition.Bottom,
                StringFormat = "dd" //화면에 보여질 단위를 정한다.
            });

            // Y 축은 값입니다.
            model.Axes.Add(new LinearAxis
            {
                Title = "값",
                Position = AxisPosition.Left
            });



            PlotChart.Model = model;
        }

        private void CreateBarChart(PlotModel plotModel, Dictionary<DateTime, double> dataList)
        {

            // 각 포인트의 데이터를 model 에 add 합니다.
            // 여기서 PointAnnotation 는 각 포인트에 라벨을 표시하기 위함입니다.
            var Points = new List<DataPoint>();
            //int idx = 0;
            foreach (var i in dataList)
            {
                var pointAnnotation = new PointAnnotation();
                pointAnnotation.X = TimeSpanAxis.ToDouble(i.Key);
                pointAnnotation.Y = i.Value;
                // 실제 데이터 값을 포인트에 add 합니다.
                Points.Add(new DataPoint(TimeSpanAxis.ToDouble(i.Key), i.Value));

                // 해당 포인트에 대한 라벨표시값도 추가합니다.
                //pointAnnotation.TextVerticalAlignment = VerticalAlignment.Top;
                //pointAnnotation.TextHorizontalAlignment = HorizontalAlignment.Center;
                //pointAnnotation.Text = (i.Value).ToString("#.00");
                //plotModel.Annotations.Add(pointAnnotation);
            }

            // Line 차트를 그리기 위한 라인시리즈를 정의합니다.
            var s = new LineSeries();
            //s.LineStyle = LineStyle.Dot;

            // 각 포인트에 동그란 점으로 표시하게 합니다.
            s.MarkerType = MarkerType.Circle;
            // 정의한 포이트 데이터들을 라인시리즈의 소스로 적용합니다.
            s.ItemsSource = Points;
            // 차트에 적용할 model 에 추가합니다.
            plotModel.Series.Add(s);

        }

    }
}
