using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MediaRepository : IMediaRepository
    {
        private readonly SQLContext __context;

        public MediaRepository(SQLContext context)
        {
            __context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> IsMediaExistAsync(string path)
        {
            return await __context.Media.AnyAsync(t => t.PathToMedia == path);
        }

        public async Task UpdateMediaDeleteStatusAsync(string path, bool newStatus)
        {
            var media = await __context.Media.FirstOrDefaultAsync(m => m.PathToMedia == path);
            media.isDeleted = newStatus;
            await __context.SaveChangesAsync();
        }

        public async Task<Media> GetMediaByPathAsync(string path)
        {
            return await __context.Media.FirstOrDefaultAsync(m => m.PathToMedia == path);
        }

        public async Task AddMediaToDatabaseAsync(string name, string pathToMedia, User user, MediaType mediaType)
        {
            __context.Media.Add(new Media
            {
                Id = 1,
                Name = name,
                PathToMedia = pathToMedia,
                isDeleted = false,
                UserId = user.Id,
                MediaTypeId = mediaType.Id
            });
            await __context.SaveChangesAsync();
        }

        public async Task<bool> IsMediaTypeExistAsync(string type)
        {
            return await __context.MediaTypes.AnyAsync(m => m.Type == type);
        }

        public async Task AddMediaTypeToDatabaseAsync(string type)
        {
            __context.MediaTypes.Add(new MediaType
            {
                Type = type
            });
            await __context.SaveChangesAsync();
        }

        public async Task<MediaType> GetMediaTypeAsync(string type)
        {
            return await __context.MediaTypes.FirstOrDefaultAsync(m => m.Type == type);
        }
    }
}
