using Discount.Application.Commands;
using Discount.Core.Model.Discounts;
using DIscount.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handlers
{
    public class DeleteDiscountByProductIDCommandHandler
        : IRequestHandler<DeleteDiscountByProductIDCommand, bool>
    {
        private readonly DiscountRepository _discountRepository;

        public DeleteDiscountByProductIDCommandHandler(DiscountRepository discountRepository)
        {
            this._discountRepository = discountRepository;
        }

        public async Task<bool> Handle(DeleteDiscountByProductIDCommand request,
            CancellationToken cancellationToken)
        {
            DiscountModel? discountModel
                = this._discountRepository.Discounts
                    .Where(e => e.ProductID == request.productID).FirstOrDefault();

            if (discountModel == null)
                throw new Exception("Discount is not available");

            this._discountRepository.Remove(discountModel);
            await this._discountRepository.SaveChangesAsync();

            return true;
        }
    }
}
