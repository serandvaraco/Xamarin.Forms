﻿using System;
using System.ComponentModel;
using AppKit;
using RectangleF = CoreGraphics.CGRect;
using SizeF = CoreGraphics.CGSize;

namespace Xamarin.Forms.Platform.MacOS
{
	public class BoxViewRenderer : ViewRenderer<BoxView, FormsNSView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new FormsNSView());
				}
				SetBackgroundColor(Element.Color);
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == BoxView.ColorProperty.PropertyName)
				SetBackgroundColor(Element.BackgroundColor);
			else if (e.PropertyName == VisualElement.IsVisibleProperty.PropertyName && Element.IsVisible)
				SetNeedsDisplayInRect(Bounds);
		}

		protected override void SetBackgroundColor(Color color)
		{
			if (Element == null || Control == null)
				return;

			Control.BackgroundColor = color.ToNSColor();
		}
	}
}
