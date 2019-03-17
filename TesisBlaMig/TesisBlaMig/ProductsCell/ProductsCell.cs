using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TesisBlaMig
{
  public class ProductsCell: ViewCell
    {
        public ProductsCell()
        {
            var prodructIDLabel = new Label {
                HorizontalTextAlignment = TextAlignment.End,
                //  XAlign = TextAlignment.End,
                FontSize = 20,
                HorizontalOptions =LayoutOptions.Start,
               
            };
            prodructIDLabel.SetBinding(Label.TextProperty, new Binding("productID"));
                  var descriptionLabel = new Label {
                  HorizontalTextAlignment=TextAlignment.End,

             HorizontalOptions = LayoutOptions.FillAndExpand
            };
            descriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));
             var  priceLabel = new Label{
                  HorizontalTextAlignment = TextAlignment.End,
                //XAlign = TextAlignment.End,
                  HorizontalOptions = LayoutOptions.End,
                  TextColor =Color.White
            };
             priceLabel.SetBinding(Label.TextProperty, new Binding("PriceFormated"));
            View = new StackLayout {
                Children = {prodructIDLabel,descriptionLabel,priceLabel},
                Orientation= StackOrientation.Horizontal



            };
            

        }

    }
}
