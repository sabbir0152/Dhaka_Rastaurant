using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.DeleteMenuCategory;
public record DeleteMenuCategoryCommand(Guid Id) : ICommand<IResult>;
