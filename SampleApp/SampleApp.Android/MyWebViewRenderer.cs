using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using SampleApp;
using SampleApp.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(MyWebView), typeof(MyWebViewRenderer))]
namespace SampleApp.Droid
{
    public class MyWebViewRenderer : WebViewRenderer
    {
        Context _context;

        public MyWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            var settings = Control.Settings;
            settings.JavaScriptEnabled = true;
            settings.SetPluginState(WebSettings.PluginState.On);

            Control.SetWebViewClient(new MyWebviewClient());


            var webview = Element as MyWebView;

            Control.LoadUrl("https://drive.google.com/viewerng/viewer?embedded=true&url=" + webview.Uri);
        }
    }

    internal class MyWebviewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            return false;
        }
    }
}