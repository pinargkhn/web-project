using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace BusBookingSystem
{
    public class BundleConfig
    {
        // Paketleme hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkId=303951 adresini ziyaret edin.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/js/WebForms/WebForms.js",
                            "~/js/WebForms/WebUIValidation.js",
                            "~/js/WebForms/MenuStandards.js",
                            "~/js/WebForms/Focus.js",
                            "~/js/WebForms/GridView.js",
                            "~/js/WebForms/DetailsView.js",
                            "~/js/WebForms/TreeView.js",
                            "~/js/WebForms/WebParts.js"));

            // Bu dosyaların çalışması için sıralama çok önemlidir; özel bağımlılıklar vardır
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/js/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/js/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/js/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/js/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            //Geliştirme yapmak ve öğrenmek için Modernizr'ın Geliştirme sürümünü kullanın. Üretim için hazır
            // üretim için hazır. https://modernizr.com adresinde derleme aracını kullanarak yalnızca ihtiyacınız olan sınamaları seçin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/js/modernizr-*"));
        }
    }
}