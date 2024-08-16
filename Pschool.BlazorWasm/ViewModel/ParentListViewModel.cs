    using Pschool.Core.DTOs;

    namespace Pschool.BlazorWasm.ViewModel;

    public class ParentListViewModel
    {
        public List<ParentDto> Parents { get; set; } = new();
        public int? EditingParentId { get; set; } = null;
        public bool IsAddingNewParent { get; set; } = false;
    }