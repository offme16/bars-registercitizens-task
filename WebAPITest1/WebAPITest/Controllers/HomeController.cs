using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPITest.Model;
using System.Data;


namespace WebAPITest.Controllers
{

    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly ContextDatabase _contextDatabase;

    
        public HomeController(ContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        /// <summary>
        /// Получение списка людей с возможностью пагинации.
        /// </summary>
        /// <param name="_limit">Количество записей на странице.</param>
        /// <param name="_page">Номер страницы.</param>
        /// <returns></returns>
        /// <response code="200">Список людей.</response>
        /// <response code="500">Ошибка на сервере</response>
        [HttpGet]
        [Route("people")]
        public async Task<IActionResult> GetPeople(int _limit, int _page = 1)
		{

            if (_limit <= 0 || _page <=0)
            {

                return Ok(await _contextDatabase.People!.ToListAsync());
            }
            var result = await _contextDatabase.People!
                  .OrderByDescending(x => x.Id)
                  .Take(_page * _limit)
                     .ToListAsync();

                return Ok(result);
             
        }

        /// <summary>
        /// Создание новой записи о человеке.
        /// </summary>
        /// <param name="people">Данные о человеке для создания записи.</param>
        /// <returns></returns>
        /// <response code="200">Созданная запись о человеке.</response>
        /// <response code="500">Ошибка на сервере</response>
        [HttpPost]
        [Route("people")]
        public async Task<IActionResult> CreateList([FromBody] People people)
        {
            await _contextDatabase.AddAsync(people);
            await _contextDatabase.SaveChangesAsync();

            return Ok(people);

        }

        /// <summary>
        /// Удаление записи о человеке по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор записи о человеке для удаления.</param>
        /// <returns></returns>
        /// <response code="200">Идентификатор удаленной записи о человеке или сообщение "не найдена" в случае отсутствия записи.</response>
        /// <response code="404">Человек не найден</response>
        /// <response code="500">Ошибка на сервере</response>
        [HttpDelete]
        [Route("people")]
        public async Task<IActionResult> DeletePeople(int id)
        {
            var person = await _contextDatabase.People!.FirstOrDefaultAsync(p => p.Id == id);

            if (person is null)
            {
                return BadRequest("не найдена");
            }

            _contextDatabase.People!.Remove(person);
            await _contextDatabase.SaveChangesAsync();

            return Ok(id);


        }

        /// <summary>
        /// Изменение данных о человеке.
        /// </summary>
        /// <param name="people">Данные о человеке для обновления записи.</param>
        /// <returns></returns>
        /// <response code="200">Измененные данные о человеке</response>
        /// <response code="500">Ошибка на сервере</response>
        [HttpPut]
        [Route("people")]
        public async Task<IActionResult> Changepeople([FromBody] People people)
        {
            _contextDatabase.People!.Update(people);
            await _contextDatabase.SaveChangesAsync();


            return Ok(people);
        }

        /// <summary>
        /// Поиск людей по имени и/или диапазону даты рождения.
        /// </summary>
        /// <param name="search">Значение поиска по имени.</param>
        /// <param name="dateStringStart">Дата начала диапазона поиска.</param>
        /// <param name="dateStringEnd">Дата конца диапазона поиска.</param>
        /// <returns></returns>
        /// <response code="200">Список людей, соответствующих критериям поиска.</response>
        /// <response code="500">Ошибка на сервере</response>
        [HttpGet]
        [Route("people/search")]
        public async Task<IActionResult> Search(string search, string dateStringStart, string dateStringEnd)
        {
            var query = _contextDatabase.People!.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower().Replace(" ", "");
                query = query.Where(x => EF.Functions.Like(x.FullName, $"%{search}%"));
            }

            if (!string.IsNullOrEmpty(dateStringStart) && !string.IsNullOrEmpty(dateStringEnd))
            {
                var dateStart = DateOnly.Parse(dateStringStart);
                var dateEnd = DateOnly.Parse(dateStringEnd);
                query = query.Where(x => x.BirthDate >= dateStart && x.BirthDate <= dateEnd);
            }

            var result = await query.ToListAsync();

            return Ok(result);

        }

    }
}
