using AutoMapper;
using NotesOrganizer.Core.Domain;
using NotesOrganizer.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesOrganizer.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Note, NoteDto>();
            })
            .CreateMapper();
    }
}
