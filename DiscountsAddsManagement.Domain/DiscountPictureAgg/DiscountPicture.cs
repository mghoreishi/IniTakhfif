using _0_Framework.Domain;
using DiscountsAddsManagement.Domain.DiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsAddsManagement.Domain.DiscountPictureAgg
{
    public class DiscountPicture: EntityBase
    {
        public long DiscountId { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemoved { get; private set; }
        public Discount Discount { get; private set; }

        public DiscountPicture(long discountId, string picture, string pictureAlt, string pictureTitle)
        {
            DiscountId = discountId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemoved = false;
        }

        public void Edit(long discountId, string picture, string pictureAlt, string pictureTitle)
        {
            DiscountId = discountId;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
