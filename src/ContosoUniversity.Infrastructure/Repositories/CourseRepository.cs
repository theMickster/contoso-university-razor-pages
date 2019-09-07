﻿using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Infrastructure.Repositories
{
    public class CourseRepository : EfRepository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _dbContext.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Course> GetCourseAsync(int? courseId)
        {
            return await _dbContext.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.CourseID == courseId);
        }

    }
}