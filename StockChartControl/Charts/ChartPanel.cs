﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using StockChartControl.Charts;
using StockChartControl.Enums;
using StockChartControl.Model;

namespace StockChartControl.UIElements
{
    /// <summary>
    /// Visual element that can contain chart data, technical indicators and technical analysis drawings.
    /// A chart is composed of one or more ChartPanels.
    /// </summary>
    public class ChartPanel : Canvas
    {
        private DrawingGroup graphContents;
        private SeriesType seriesType;
        private IndicatorType? indicatorType;
        private IChartDrawing chartDrawing;

        public ChartPanel(ChartOptions options)
        {
            this.seriesType = options.SeriesType;
            this.indicatorType = options.IndicatorType;
            this.chartDrawing = ChartDrawingHelper.GetChartDrawing(seriesType, indicatorType);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (graphContents == null)
				graphContents = new DrawingGroup();

            using (DrawingContext context = graphContents.Open())
            {
                var bounds = new Rect(0, 0, 100, 100);
                var brush = new SolidColorBrush(Colors.BlueViolet);
                context.DrawRectangle(brush, null, bounds);

                chartDrawing.Draw(context);
            }

            drawingContext.DrawDrawing(graphContents);
        }

    }
}