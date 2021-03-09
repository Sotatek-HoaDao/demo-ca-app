using demo_ca_app.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMovieCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified title already exists.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(v => v.Duration)
                .NotEmpty().WithMessage("Duration is required.");
        }

        public async Task<bool> BeUniqueName(UpdateMovieCommand model, string name, CancellationToken cancellationToken)
        {
            return await _context.Movies
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.Name != name);
        }
    }
}
