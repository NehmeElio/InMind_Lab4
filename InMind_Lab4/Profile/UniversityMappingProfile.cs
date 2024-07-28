using InMind_Lab4.Model;
using InMind_Lab4.ViewModel;

namespace InMind_Lab4.Profile
{
    public class UniversityMappingProfile : AutoMapper.Profile
    {
        public UniversityMappingProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => CalculateAge(src.DateOfBirth)))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<Teacher, TeacherViewModel>();
            CreateMap<Course, CourseViewModel>();
            CreateMap<Class, ClassViewModel>();
            CreateMap<Enrollment, EnrollmentViewModel>();
        }

        private int CalculateAge(DateOnly? dateOfBirth)
        {
            if (dateOfBirth == null)
                return 0;
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Value.Year;
            //add if bday happens or not
            return age;
        }
    }
}