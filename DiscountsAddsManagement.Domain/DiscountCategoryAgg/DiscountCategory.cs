using _0_Framework.Domain;
using DiscountsAddsManagement.Domain.DiscountAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsAddsManagement.Domain.DiscountCategoryAgg
{
    public class DiscountCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public string Picture { get; private set; }

        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public List<Discount> Discounts { get; set; }

        public DiscountCategory(string name, string description, string pictureTitle, string pictureAlt, 
                                string picture, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Picture = picture;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Edit(string name, string description, string pictureTitle, string pictureAlt,
                                string picture, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Picture = picture;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
    }

  



}
