using _0_Framework.Domain;
using DiscountsAddsManagement.Domain.DiscountCategoryAgg;
using DiscountsAddsManagement.Domain.DiscountPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Domain.DiscountAgg
{
    public class Discount: EntityBase
    {
        public string Name { get; private set; }
        public string T { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public bool IsActived { get; private set; }
        public DiscountCategory Category { get; private set; }
        public List<DiscountPicture> DiscountPictures { get; private set; }

        public Discount(string name, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, long categoryId, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            IsActived = true;
            IsCanceled = true;
        }

        public void Edit(string name, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, long categoryId, string slug,
            string keywords, string metaDescription,string dsc)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Description = dsc;
        }
        public void Confirm()
        {
            IsConfirmed = true;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }

        public void Active()
        {
            IsActived = true;
        }

        public void InActive()
        {
            IsActived = false;
        }
    }
}
