using Microsoft.EntityFrameworkCore;
using ShelterData.Data;

namespace ShelterData;

public class ShelterContext : DbContext
{
	public DbSet<SpecialCondition> SpecialConditions => Set<SpecialCondition>();
	public DbSet<Profession> Professions => Set<Profession>();
	public DbSet<Disaster> Disasters => Set<Disaster>();
	public DbSet<Shelter> Shelters => Set<Shelter>();
	public DbSet<Luggage> Luggage => Set<Luggage>();
	public DbSet<Biology> Biology => Set<Biology>();
	public DbSet<Hobbie> Hobbies => Set<Hobbie>();
	public DbSet<Health> Health => Set<Health>();
	public DbSet<Fact> Facts => Set<Fact>();

	public bool IsEmpty =>
		!SpecialConditions.Any() ||
		!Professions.Any() ||
		!Disasters.Any() ||
		!Shelters.Any() ||
		!Luggage.Any() ||
		!Biology.Any() ||
		!Hobbies.Any() ||
		!Health.Any() ||
		!Facts.Any();

	public ShelterContext() => Database.EnsureCreated();

	protected override void OnConfiguring(
	  DbContextOptionsBuilder optionsBuilder) =>
	  optionsBuilder.UseSqlite("Data Source=ShelterData.db");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Biology>().HasData(
			new Biology(Id: 1, Description: "АНДРОИД"),
			new Biology(Id: 2, Description: "ЖЕНЩИНА 18 ЛЕТ"),
			new Biology(Id: 3, Description: "ЖЕНЩИНА 19 ЛЕТ ГОМОСЕКСУАЛЬНА"),
			new Biology(Id: 4, Description: "ЖЕНЩИНА 21 ГОД"),
			new Biology(Id: 5, Description: "ЖЕНЩИНА 22 ГОДА БИСЕКСУАЛЬНА"),
			new Biology(Id: 6, Description: "ЖЕНЩИНА 24 ГОДА"),
			new Biology(Id: 7, Description: "ЖЕНЩИНА 25 ЛЕТ ГОМОСЕКСУАЛЬНА"),
			new Biology(Id: 8, Description: "ЖЕНЩИНА 27 ЛЕТ"),
			new Biology(Id: 9, Description: "ЖЕНЩИНА 30 ЛЕТ"),
			new Biology(Id: 10, Description: "ЖЕНЩИНА 31 ГОД"),
			new Biology(Id: 11, Description: "ЖЕНЩИНА 33 ГОДА ГОМОСЕКСУАЛЬНА"),
			new Biology(Id: 12, Description: "ЖЕНЩИНА 34 ГОДА"),
			new Biology(Id: 13, Description: "ЖЕНЩИНА 36 ЛЕТ"),
			new Biology(Id: 14, Description: "ЖЕНЩИНА 65 ЛЕТ"),
			new Biology(Id: 15, Description: "ЖЕНЩИНА 99 ЛЕТ"),
			new Biology(Id: 16, Description: "КОТГЕНДЕР"),
			new Biology(Id: 17, Description: "МУЖЧИНА 18 ЛЕТ"),
			new Biology(Id: 18, Description: "МУЖЧИНА 23 ЛЕТ ГОМОСЕКСУАЛЕН"),
			new Biology(Id: 19, Description: "МУЖЧИНА 24 ГОДА БИСЕКСУАЛЕН"),
			new Biology(Id: 20, Description: "МУЖЧИНА 26 ЛЕТ"),
			new Biology(Id: 21, Description: "МУЖЧИНА 27 ЛЕТ ГОМОСЕКСУАЛЕН"),
			new Biology(Id: 22, Description: "МУЖЧИНА 29 ЛЕТ"),
			new Biology(Id: 23, Description: "МУЖЧИНА 31 ГОД"),
			new Biology(Id: 24, Description: "МУЖЧИНА 32 ГОДА ГОМОСЕКСУАЛЕН"),
			new Biology(Id: 25, Description: "МУЖЧИНА 33 ГОДА"),
			new Biology(Id: 26, Description: "МУЖЧИНА 35 ЛЕТ"),
			new Biology(Id: 27, Description: "МУЖЧИНА 39 ЛЕТ"),
			new Biology(Id: 28, Description: "МУЖЧИНА 42 ЛЕТ ГОМОСЕКСУАЛЕН"),
			new Biology(Id: 29, Description: "МУЖЧИНА 75 ЛЕТ"),
			new Biology(Id: 30, Description: "МУЖЧИНА 101 ГОД")
		);

		modelBuilder.Entity<Shelter>().HasData(
			new Shelter(Id: 1, Description: "РОБОТ-ПСИХОЛОГ. МОЛЧА СЛУШАЕТ И КИВАЕТ, ИНОГДА ЧТО-ТО ПИЛИКАЕТ. ПРИГОДИТСЯ НА ЗАПЧАСТИ, ЕСЛИ ЧТО."),
			new Shelter(Id: 2, Description: "У ВХОДА ЕСТЬ АПТЕЧКИ, РЕЗИНОВЫЕ ПЕРЧАТКИ, МАСКИ И ОГНЕТУШИТЕЛЬ"),
			new Shelter(Id: 3, Description: "НА СТЕНЫ ПРОЕЦИРУЕТСЯ РЕЛАКСАЦИОННОЕ ВИДЕО СЪЁМОК СО СПУТНИКА. КРАСИВО И УМИРОТВОРЯЮЩЕ. ОГО, ДА ВЕДЬ ЭТО ОКРЕСНОСТИ БУНКЕРА! И ДЕТАЛИЗАЦИЯ ОТЛИЧНАЯ."),
			new Shelter(Id: 4, Description: "ЭТОТ БУНКЕР ОТКРОЕТСЯ И ВЫПУСТИТ ВАС ТОЛЬКО ЧЕРЕЗ 10 ЛЕТ. ЗАПАС ЕДЫ СООТВЕТСТВУЮЩИЙ. НО ЗА ЭТО ВРЕМЯ НАВЕРНЯКА СЛУЧИТСЯ НЕ ОДНА НЕПРИЯТНОСТЬ. В ФИНАЛЕ ОТКРОЙТЕ ДОПОЛНИТЕЛЬНУЮ УГРОЗУ"),
			new Shelter(Id: 5, Description: "МОДУЛЬ ГИПНО-ТЕЛЕПАТИЧЕСКОЙ КОММУНИКАЦИИ И ДЕТЕКТОР ПАРАНОРМАЛЬНЫХ ПОЛЕЙ."),
			new Shelter(Id: 6, Description: "БУНКЕРОМ УПРАВЛЯЕТ ИИ С ГОЛОСОВЫМ ИНТЕРФЕЙСОМ. КОМАНДЫ ОН ПОНИМАЕТ С ПЯТОЙ ПОПЫТКИ."),
			new Shelter(Id: 7, Description: "ИЗ ЗАПАСОВ ПРОДОВОЛЬСТВИЯ ТОЛЬКО ГРЕЧКА. ЗАТО ОЧЕНЬ МНОГО, ПОХОЖЕ ДВОЙНОЙ ЗАПАС."),
			new Shelter(Id: 8, Description: "РЕЗЕРВНЫЙ ЭЛЕКТРОГЕНЕРАТОР С ВЕЛОПРИВОДОМ И КУЧА МЕТАЛЛОЛОМА."),
			new Shelter(Id: 9, Description: "СПАЛЬНЫХ МЕСТ РОВНО ПО ЧИСЛУ ЛЮДЕЙ. ОДНО ИЗ НИХ СТОИТ ОБОСОБЛЕННО И ПОХОЖЕ НА ЖЕРТВЕННЫЙ АЛТАРЬ."),
			new Shelter(Id: 10, Description: "СТРАННЫЙ СТАРЫЙ ЖУРНАЛ, В КОТОРОМ ИМЕНА ВСЕЙ ВАШЕЙ КОМАНДЫ, КТО СТОИТ У БУНКЕРА. РЯДОМ ДАТЫ 33-ЛЕТНЕЙ ДАВНОСТИ... И ТОЧНОЕ ОПИСАНИЕ ВСЕГО, ЧТО С ВАМИ ПРОИСХОДИТ. В ФИНАЛЕ НЕ ОТКРЫВАЙТЕ 1 КАРТУ УГРОЗЫ."),
			new Shelter(Id: 11, Description: "БИБЛИОТЕКА КОНТРАБАНДИСТА. КТО ТОЛЬКО НЕ ПРЯТАЛСЯ В ЭТОМ БУНКЕРЕ. ДЕТАЛЬНО ОПИСАНЫ ВСЕЦЕННЫЕ ПРЕДМЕТЫ ИСКУСТВА, КОТОРЫЕ ЕСТЬ В ОКРУГЕ, С МАРШРУТАМИ ВЫВОЗА МИМО ПОЛИЦИИ."),
			new Shelter(Id: 12, Description: "В БУНКЕРЕ НЕТТ УАЛЕТНОЙ БУМАГИ. ЗАТО ВЫ НАШЛИ ИНСТРУКЦИЮ ПО ПЕРЕПРОГРАММИРОВАНИЮ МИКРОВОЛНОВКИ НА 7174. ЯЗЫКАХ. МОЖНО И ПРОГРАММИРОВАНИЮ НАУЧИТСЯ, И ЯЗЫКИ ВЫУЧИТЬ."),
			new Shelter(Id: 13, Description: "МАСТЕРСКАЯ С ИНСТРУМЕНТАМИ"),
			new Shelter(Id: 14, Description: "КОФЕМОЛКА ИЗАПАС АРОМАТНОГО ОБЖАРЕННОГО ЗЕРНОВОГО КОФЕ. НАПОМИНАНИЕ О НОРМАЛЬНОЙ ЖИЗНИ ДО ВСЕГО ЭТОГО БУЗУМИЯ..."),
			new Shelter(Id: 15, Description: "ПОХОЖЕ, ЧТО В БУНКЕРЕ ОБИТАЮТ ПОЛЧИЩА КРЫС ИЛИ КАКИХ-ТО ГРЫЗУОВ. В КРИТИЧЕСКОЙ СИТУАЦИИ ИЛИ МЫ ДЛЯ НИХ ЕДА, ИЛИ ОНИ ДЛЯ НАС"),
			new Shelter(Id: 16, Description: "КНИГА «О ВКУСНОЙ И ЗДОРОВОЙ ПИЩЕ КАК ПРЕДМЕТЕ ИСКУСТВА И КУЛЬТУРЫ». С ЦЕННЫМИ ГЛАВАМИ О ТОМ, КАК ДОБЫВАТЬ И ГОТОВИТЬ ВКУСНУЮ ЕДЕ ДАЖЕ В СУМЫХ ЭКСТРЕМАЛЬНЫХУСЛОВИЯХ."),
			new Shelter(Id: 17, Description: "ИЗ ПОДВАЛА ЕСТЬ ВЫХОД В ЕСТЕСТВЕННЫЙ ГРОТ С ПОДЗЕМНОЙ РЕКОЙ. СУДЯ ПО ЗАПАХУ, ПО РЕКЕ МОЖНО ПОПАСТЬ В РАЗВАЛЕННУЮ СИСТЕМУ ГОРОДСКОЙ КАНАЛИЗАЦИИ И ВЫЙТИ КУДА УГОДНО."),
			new Shelter(Id: 18, Description: "С ПЕРЕБОЯМИ РАБОТАЕТ ЭЛЕКТРИЧЕСКОЕ ОСВЕЩЕНИЕ. НО ЕСТЬ КЕРОСИНОВЫЕ ЛАМПЫ И ЗАПАС ТОПЛИВА. КОКТЕЙЛИ МОЛОТОВА ПРИГОДЯТСЯ ДЛЯ ЗАЩИТЫ."),
			new Shelter(Id: 19, Description: "МЕДИЦИНСКАЯ ЛАБОРАТОРИЯ С ОПЕРАЦИОННОЙ"),
			new Shelter(Id: 20, Description: "ЕСТЬ АВТОНОМНАЯ МЕДИАТЕКА, НО В НЕЙ ТОЛЬКО ПОРНОФИЛЬМЫ КАЖЕТСЯ, ЗА ВСЮ ИСТОРИЮ КИНЕМАТОГРАФА"),
			new Shelter(Id: 21, Description: "ДЫРЯВЫЕ МАТРАСЫ И ТРЯПКИ, БРОШЕННЫЙ СТРОИТЕЛЬНЫЙ МУСОР. СРЕДИ МУСОРА - СТАРИННЫЕ ГАЗЕТЫ АЖ 2022 ГОДА!"),
			new Shelter(Id: 22, Description: "ПЕРЕНОСНОЙ ГЕНЕРАТОР ЗАЩИТНОГО СИЛОВОГО ПОЛЯ"),
			new Shelter(Id: 23, Description: "БУНКЕР СТРОИЛИ ЗАКЛЮЧЕННЫЕ. ЖУТКИЙ ЗАПАХ ПРИВЕЛ ВАС В ПОДВАЛ, ГДЕ ВЫ НАШЛИ ИХ ОСТАНКИ. А ЗАОДНО ИХ ИНСТРУМЕНТЫ И ОРУЖИЕ ОХРАННИКОВ"),
			new Shelter(Id: 24, Description: "ПО ВНУТРЕННЕМУ РАДИО КЛАССИЧЕСКУЮ МУЗЫКУ ПОСТОЯННО СМЕНЯЕТ КИРКОРОВ. МОЖНО ПОТРЕНИРОВАТЬ СТРЕССОУСТОЙЧИВОСТЬ"),
			new Shelter(Id: 25, Description: "В РЕЗУЛЬТАТЕ ТЕКТОНИЧЕСКИХ СДВИГОВ БУНКЕР СЛЕГКА НАКЛОНЕН. ГДЕ-ТО НА 45 ГРАДУСОВ"),
			new Shelter(Id: 26, Description: "ОГРОМНЫЙ ДРЕВНИЙ ФАЛИАНТ НА НЕИЗВЕСТНОМ ЯЗЫКЕ С МИСТИЧЕСКИМИ ИЛЛЮСТРАЦИЯМИ. ПОХОЖЕ НА ГРЕМУАР С ЗАКЛИНАНИЯМИ И АНОТОМИЧЕСКУЮ ЭНЦИКЛОПЕДИЮ"),
			new Shelter(Id: 27, Description: "АВТОНОМНЫЙ РОБОТ-ПЕРЕВОДЧИК С ФУНКЦИЕЙ ПОЛИГРАФА. ПРИГОДИТСЯ ДЛЯ СЛОЖНЫХ ПЕРЕГОВОРОВ"),
			new Shelter(Id: 28, Description: "ШКАФ С НАСТОЛЬНЫМИ ИГРАМИ! ПОГОДИТЕ-КА, НО ТУТ ТОЛЬКО ВСЕ ВОЗМОЖНЫЕ ВИДЫ МОНОПОЛИИ... ХОРОШО, ЧТО НАМ НЕКУДА СПЕШИТЬ"),
			new Shelter(Id: 29, Description: "УЧЕБНОЕ ПОСОБИЕ «КАК УБЕДИТЬ ЗОМБИ НЕ ЖРАТЬ ВАШ МОЗГ»"),
			new Shelter(Id: 30, Description: "ХИМ. ЛАБОРАТОРИЯ И РЕАКТИВЫ. МОЖНО УСТРОИТЬ ГИДРОПОНИЧЕСКУЮ ФЕРМУ")
		);

		modelBuilder.Entity<Disaster>().HasData(
			new Disaster(Id: 1, Description: "ГРАВИТАЦИОННАЯ АНОМАЛИЯ ПРИВОДИТ КРАСШИРЕННИЮ ОБЪЕМА ВОДЫ И ЗАТОПЛЕНИЮ ВСЕЙ ПОВЕРХГОСТИ СУШИ. ВЫЙДЯ ИЗ БУНКЕРА ПОСЛЕ ЧАСТИЧНОГО СПАДА ВОДЫ, ВАМ ПРЕДСТОИТ ПОСТРОИТЬ ПЛАВУЧУЮ СТАНЦИЮ, ЖИТЬ И ДОБЫВАТЬ ПРОПИТАНИЕ НА ВОДЕ ПОКА НЕ НАЙДЕТЕ УЧАСТКИ СУШИ, ПРИГОДНЫЕ ДЛЯ ЖИЗНИ."),
			new Disaster(Id: 2, Description: "СПЕРВА РОБОТ ЕЕДОГ 5КУБОЕ Е-850 ИЗ РОССИЙСКОЙ КОСМИЧЕСКОЙ ПРОГРАММЫ ЗАХВАТИЛ СОЦСЕТИ И ПОДНЯЛ БУНТ В ЗАЩИТУ СВОБОДЫ СЛОВА РОБОТОВ. А ЗАТЕМ УЖЕ ВСЕ ЭЛЕКТРОННЫЕ УСТРОЙСТВА ОБЪЕДИНИЛИСЬ В БОРЬБЕ ПРОТИВ ЛЮДЕЙ-УГНЕТАТЕЛЕЙ. ПЫЛЕСОСЫ АТАКУЮТ И ЗАСАСЫВАЮТ ЛЮДЕЙ. СОТОВЫЕ ТЕЛЕФОНЫ ПРОЖАРИВАЮТ МИЗГ СВОИХ ВЛАДЕЛЬЦЕВ. ВЕЗДЕСУЩИЕ ГАДЖЕТЫ НЕ ОСТАВЛЯЮТ ЧЕЛОВЕЧЕСТВУ ШИНСОВ. ЗАТАИТЕСЬ В БУНКЕРЕ, ЧТОБЫ ЗАТЕМ СОБРАТЬ СИЛЫ И ОБЪЯВИТЬ ВОЙНУ РОБОТАМ ИЭЛЕКТРОННЫМ ГАДЖЕТАМ."),
			new Disaster(Id: 3, Description: "УЧЕНЫМ УДАЛОСЬ ВОСКРЕСИТЬ ДИНОЗАВРОВ. НО СИТУАЦИЯ ВЫШЛА ИЗ-ПОД КОНТРОЛЯ. ДОИСТОРИЧЕСКИЕ МОНСТРЫ ВЫРВАЛИСЬ НА СВОБОДУ И СТАЛИ РАЗМНОЖАТЬСЯ НЕВЕРОЯТНОЙ СКОРОСТЬЮ. СТАИ ДИНОЗАВРОВ СМЕТАЮТ ВСЮ ПИЩУ, КОТОРУЮ НАХОДЯТ РАСТИТЕЛЬНОСТЬ, ЖИВОТНЫХ, ЛЮДЕЙ. РАЗРУШЕНЫ ИНФРАСТРУКТУРЫ ГОРОДОВ. ПЕРЕЖИВ ПИК УГРОЗЫ В БУНКЕРЕ, ВЫ ВЫЙДЕТЕЕ НА ОПУСТОШЕННУЮ ПОВЕРХНОСТЬ. ЕСТЬ НАДЕЖДА, ЧТО С НЕДОСТАТКОМ ПИЩИ ЧИСЛЕННОСТЬ ДИНОЗАВРОВ СОКРАТИТСЯ: ВАМ ПРЕДСТОИТ ОБЕСПЕЧИТЬ СВОЕ ПРОПИТАНИЕ И НЕ СТАТЬ САМИМ ЕДОЙ ДЛЯ НОВЫХ ХОЗЯЕВ МИРА."),
			new Disaster(Id: 4, Description: "НА ЗЕМЛЕ ВОЦАРИЛАСЬ ВЕЧНАЯ ЖИЗНЬ. ЛЮДИ УВЛЕКЛИСЬ МИСТИЧЕСКОЙ ЛИТЕРАТУРОЙ, И МАССОВАЯ ВЕРА В ПРИЗРАКОВ ПРИДАЛА ДУХАМ РЕАЛЬНУЮ МАГИЧЕСКУЮ СИЛУ. ОКАЗАЛОСЬ, ЧТО КТО-ТО В ОДНОМ ИЗ КУЛЬТУРНЫХ ПРОИЗВИДЕНИЙ СОЗДАЛ ФОРМУЛУ, ПОЗВОЛЯЮЩУЮ ДУХАМ ПОПАДАТЬ В РЕАЛЬНЫЙ МИР. ПРИЗРАКИ СТАЛИ ПРОНИКАТЬ В ГОЛОВЫ ЛЮДЕЙ И ПОДЧИНЯТЬ ИХ СВОЕЙ ВЛАСТИ. ДАЖЕ ШАПОЧКИ ИЗ ФОЛЬГИ ПОМОГЛИ НЕ ВСЕМ.УКРОЙТЕСЬ В БУНКЕРЕ, ЧТОБЫ СПАСТИ РАЗУМ. ВАМ НУЖНО ВЫЧИСЛИТЬ, КАКОЙ ИМЕННО КУЛЬТУРНЫЙ ОБЪЕКТ ДАЕТ ДУХАМ ТАКУЮ СИЛУ. ТОГДА ЕГО МОЖНО БУДЕТ ЗАНЕСТИ В РЕЕСТР РОСКОМНАДЗОРА И СПАСТИ ЧЕЛОВЕЧЕСВТО."),
			new Disaster(Id: 5, Description: "ИСКУСТВЕННЫЙ ИНТЕЛЕКТ ПОДЧИНИЛ ЧЕ- ЛОВЕЧЕСТВО. СПЕРВА ЛЮДИ ПРИВЫКЛИ СЛУ- ШАТЬСЯ СОВЕТОВ АВТОНАВИГАТОРА. А ТЕПЕРЬ ИИ ДИКТУЕТ ЛЮДЯМ, КЕМ ИМ РАБОТАТЬ, С КЕМ ЖИТЬ И КОГДА УМИРАТЬ. ИИ НАУЧИЛСЯ МАНИПУЛИРОВАТЬ ЧЕЛОВЕЧЕСКИМ СОЗНАНИ- ЕМ, А ЛЮДИ ПОТЕРЯЛИ СВОБОДНУЮ ВОЛЮ. СЕЙЧАС ЖЕ ИИ РЕШИЛ, ЧТО ЛЮДИ БОЛЬШЕ НЕ НУЖНЫ, И ЧЕРЕЗ ВЫШКИ 5С ИЗЛУЧАЕТ СИГНАЛ «ПОКОНЧИТЬ С СОБОЙ». УКРОЙТЕСЬ В БУНКЕРЕ, ПОКА ВЫШКИ АКТИВ- НЫ. ЗАТЕМ ВАМ ПРЕДСТОИТ ВЗЛОМАТЬ ПРОГРАММНЫЙ КОД ИИ ИЛИ ЖЕ УБЕДИТЬ ПОСЛЕДНИХ ВЫЖИВШИХ НЕ ПОДЧИНЯТЬСЯ КО- МАНДАМ АЛГОРИТМОВ И ПОДНЯТЬ ВОССТАНИЕ."),
			new Disaster(Id: 6, Description: "НЕИЗВЕСТНЫЙ ВИРУС ПРЕВРАЩАЕТ ЛЮДЕЙ В ЗОМБИ. ПОЧТИ ВСЕ НАСЕЛЕ- НИЕ ПОГИБНЕТ, НО ЧАСТЬ ВЫЖИВЕТ В ВИДЕ АГРЕССИВНЫХ МУТАНТОВ. ОТДЕЛЬНЫЕ ГРУППЫ ЛЮДЕЙ СМОГУТ ВЫЖИТЬ В УКРЕПЛЕННЫХ ТЕРРИТОРИЯХ. ПОСЛЕ ВЫХОДА ИЗ БУНКЕРА ВАМ НУЖНО БУДЕТ ПОСТОЯННО ОТБИВАТЬСЯ ОТАТАК ЗОМБИ И НАЙТИ СПОСОБ ЗАЩИЩАТЬСЯ ОТ ВИРУСА."),
			new Disaster(Id: 7, Description: "ИНФОРМАЦИОННУЮ ВОЙНУ РАЗВЯЗАЛИ НЕ ГОСУДАРСТВА, А СОЗДАННЫЕ ЛЮДМИ НОВОСТНЫЕ АЛГОРИТМЫ. ЭФФЕКТИВНОСТЬ НОВОСТЕЙ СТАЛИ ОЦЕНИВАТЬ ПО ЭМОЦИОНАЛЬНОЙ РЕАКЦИИЛЮДЕЙ.ИСАМООБУЧАЮЩИЕСЯНЕЙРОН ЫЕ СЕТИ НАЧАЛИ ГЕНЕРИРОВАТЬ ЗАГОЛОВКИ НОВОСТЕЙ, КОТОРЫЕ СВОДИЛИ ЛЮДЕЙ С УМА. ЛЮДИ МАССОВО ВПАДАЮТ В ДЕПРЕССИИ, А ЖУРНАЛИСТЫ, УПРАВЛЯВШИЕ АЛГОРИТМАМИ -ПАЛИ ПЕРВЫМИ ЖЕРТВАМИ. ВАС ОТОБРАЛИ ДЛЯ ИЗОЛЯЦИИ ОТ НОВОСТНОГО ПОТОКА И ВОССТАНОВЛЕНИЯ -ЧТОБЫ ПОТОМ ВЫ СМОГЛИ ДОЮРАТЬСЯ ДО НОВОСТНЫХ ЦЕН- ТРОВ, НЕ ПОТЕРЯВ РАЗУМ, И ПЕРЕНАСТРОИТЬ НЕЙРОННЫЕ СЕТИ."),
			new Disaster(Id: 8, Description: "ПОЕДАНИЕ ГЕННОМОДИФИЦИРОВАННОЙ ЕДЫ НЕОЖИДАННО ПРИВЕЛО КСТРАШНЫМ ПО- СЛЕДСТВИЯМ. У ЖИВОТНЫХ И ЛЮДЕЙ НАЧАЛА ВЫРАСТАТЬ КУКУРУЗА ВСАМЫХ РАЗНЫХ МЕСТАХ, У РАСТЕНИЙ ПОЯВЛЯЮТСЯ ЗУБЫ И ОРГАНЫ ЧУВСТВ. МУТИРОВАВШИЕ ЛЮДИ СЧИТАЮТ СЕБЯ СУПЕРГЕРОЯМИ И СХОДЯТ СУМА. СТЕРТЫ ГРАНИ МЕЖДУ РАСТЕНИЯМИ, ЖИВОТНЫМИ ИЛЮДМИ. ПЕРЕЖИВ ПИК МУТАЦИОННОГО АПОКАЛИПСИ- СА В БУНКЕРЕ, ВАМ ПРЕДСТОИТ СНОВА ВЫ- РАСТИТЬ ГЕНЕТИЧЕСКИ ЧИСТЫЕ ПРОДУКТЫ И ВЫЛЕЧИТЬ ОСТАВШИХСЯ ВЖИВЫХ МУТАНТОВ"),
			new Disaster(Id: 9, Description: "КРУПНЫЙ МЕТЕОРИТ ПРИБЛИЖАЕТСЯ К ЗЕМЛЕ. СТОЛКНОВЕНИЕ ПРИВЕДЕТ К ГЛОБАЛЬНЫМ РАЗРУШЕНИЯМ, СМЕНЕ КЛИМАТА, ГИБЕЛИ ЛЮДЕЙ, ФЛОРЫ И ФАУНЫ ПОСЛЕ ВЫХОДА ИЗ БУНКЕРА ВАМ ПРЕД- СТОИТ НАЙТИ МЕСТО, ПРИГОДНОЕ ДЛЯ ПРОЖИВАНИЯ, И ОБЕСПЕЧИТЬ ПРОПИТА- НИЕ В СУРОВЫХ УСЛОВИЯХ ВЕЧНОЙ ЗИМЫ."),
			new Disaster(Id: 10, Description: "СМЕРТЕЛЬНЫЙ ВИРУС, СОЗДАННЫЙ КАК БИОЛОГИЧЕСКОЕ ОРУЖИВЕ, ВЫХОДИТ ИЗ ПОД КОНТРОЛЯ И ПРОВОЦИРУЕТ ГЛО- БАЛЬНУЮ ЭПИДЕМИЮ. ПОСЛЕ ВЫХОДА ИЗ БУНКЕРА ВАС ВСТРЕТЯТ УЖЕ МЕНЕЕ ЗАРАЗНЫЕ, НО МУТИРОВАВШИЕ ВИДЫ ЖИВОТНЫХ И ЛЮДЕЙ. ВАМ ПРИДЕТСЯ ИЗБЕГАТЬ КОНТАКТОВ СЗАРАЖЕННЫМИ, ПОДДЕРЖИВАТЬ ИММУНИТЕТ, НАЙТИ ИСТОЧНИК ЗАРАЗЫ И РАЗРАБОТАТЬ ВАКЦИНУ ОТ ВИРУСА."),
			new Disaster(Id: 11, Description: "ЩУКУ ИЗ РУССКОЙ СКАЗКИ «ЗАКЛИНЕЛО» ОНА ИСПОЛНЯЕТ ЖЕЛАНИЕ КАЖДУЮ МИНУТУ. ЛЮДИ ТО ВЗМЫВАЮТ В НЕБО, ТО ПРОВАЛИВАЮТСЯ К ЧЕРТОВОЙ МАТЕРИ, ТО ДРУЖНО ИДУТ В БАНЮ... СПАСТИ СВОЮ ЖИЗНЬ И РАСУДОК МОЖНО ТОЛЬКО В БУНКЕРЕ, ВЫЙДЯ ИЗ КОТОРОГО ПРИДЕТСЯ ВОССТАНАВЛИВАТЬ МИР, ПОРЯДОК И ПСИХИЧЕСКОЕ ЗДОРОВЬЕ ТЕХ, КТО ОСТАЛСЯ В ЖИВЫХ. ВАМ ПРИДСТОИТ НЕ ТОЛЬКО НЕ ПОТЕРЯТЬ РАЗУМ СРЕДИ БЫЛИННЫХ ЧУДЕС, НО И ПРИДУМАТЬ «КУЛЬТУРНЫЙ АНТИДОТ», ЧТОБЫ СНЯТЬ ПРОКЛЯТИЕ."),
			new Disaster(Id: 12, Description: "ПОСЛЕДСТВИЯ ОЧЕРЕДНОГО ГРИППА НЕ СРАЗУ БЫЛИ ОЧЕВИДНЫ, И НИКТО НЕ УСПЕЛ ПРЕД- ПРИНЯТЬ МЕРЫ. ЛЮДИ УТРАТИЛИ ЧУВСТВО ЭСТЕТИКИ. ОКАЗАЛОСЬ, ЧТО ОНО ЛЕЖИТ В ОСНОВЕ ОТЛИЧИЯ ЧЕЛОВЕКА ОТ ЖИВОТНЫХ, ЧЕЛОВЕЧЕСКИХ ЦЕННОСТЕЙ, МОТИВАЦИИ И ВОЛИ. ЛЮДИ ДЕГРАДИРУЮТ И ПРЕВРАЩАЮТСЯ В ДИКИХ ЖИВОТНЫХ, НЕ ОГРАНИЧЕННЫХ СТРЕМЛЕНИЯМИ К ПРЕКРАСНОМУ, ЭТИКОЙ И КУЛЬТУРОЙ. ВСЕГО НЕСКОЛЬКО ДНЕЙ, И ЦИВИ- ЛИЗАЦИИ РУХНУЛИ, А МИР ТЕПЕРЬ НАСЕЛЕН МИЛЛИАРДАМИ АГРЕССИВНЫХ ОБЕЗЬЯН. ПЕРЕЖДИТЕ ПИК АКТИВНОСТИ ВИРУСА В БУНКЕРЕ. ЗАТЕМ ВАМ ПРЕДСТОИТ ВЕРНУТЬ В МИР ЛЮДЕЙ КУЛЬТУРУ И СПАСТИ ЧЕЛОВЕЧЕСТВО."),
			new Disaster(Id: 13, Description: "АВАРИЯ ВЯДЕРНОМ ИСПЫТАТЕЛЬНОМ ЦЕНТРЕ ПРИВЕЛА К РАЗЛОМУ ВО ВРЕМЕНИ, И В НАШ МИР ПОПАЛ СТРАДАЮЩИЙ СРЕДНЕВЕКОВЫЙ ЭКСГИБИЦИОНИСТКОЛЯ. ПРЯМО СЕЙЧАС ОН БЕЗУМНО МЕЧЕТСЯ И ПУГАЕТ ЛЮДЕЙ НАШЕГО ВРЕМЕНИ. УВИДЕВ КОЛЮ, ЛЮДИ ОЦЕПЕНЕВА- ЮТ И ГОВОРЯТ «ОЙ». СКАЗАВШИХ «ОЙ» ВСЕ БОЛЬШЕ И БОЛЬШЕ, КОЛЯ ОЧЕНЬ АКТИВЕН! УКРОЙТЕСЬ ОТ КОЛИ В БУНКЕРЕ В ЭПИЦЕНТРЕ СОБЫТИЙ. ЗАТЕМ ЖЕ, НАБРАВШИСЬ СМЕЛОСТИ ИЗАВЯЗАВ СЕБЕ ГЛАЗА, ВАМ ПРЕДСТОИТ ВЕРНУТЬСЯ В МИР, ЧТО БЫ НАЙТИ КОЛЮС ЗАВЯЗАННЫМИ ГЛАЗАМИ, А ЗНАЧИТ НА ОЩУПЬ И УБЕДИТЬ ЕГО ВЕРНУТЬСЯ В СВОЕ СРЕДНЕВЕКОВЬЕ."),
			new Disaster(Id: 14, Description: "НА ПЛАНЕТЕ ПРОИСХОДИТ АНОМАЛЬНЫЙ ЭВОЛЮЦИОННЫЙ ВИТОК. ВСЯ ФАУНА СТАНОВИТСЯ СМЕРТОНОСНОЙ ДЛЯ ЛЮДЕЙ. НЕВИДИМОЕ ИЗЛУЧЕНИЕ ОТ РАСТЕНИЙ И ДЕРЕВЬЕВ СВОДИТ ЛЮДЕЙ С УМА И ЗАСТАВЛЯЕТ СОВЕРШАТЬ САМОУБИЙСТВО. БУНКЕР ПОЗВОЛИТ ВАМ ПЕРЕЖИТЬ САМУЮ ОПАСНУЮ ФАЗУ. КОГДА ВЫ ВНОВЬ ВЫЙДЕТЕ НА ПОВЕРХНОСТЬ, ВАМ НУЖНО НАЙТИ И УНИЧТОЖИТЬ ЭПИЦЕНТР ЭТОЙ АНОМАЛИИ И СОХРАНИТЬ РАССУДОК."),
			new Disaster(Id: 15, Description: "АКТИВИЗИРУЮТСЯ СУПЕРВУЛКАНЫ, ПРОИЗ- ВОДЯЩИЕ ЧЕРЕЗВЫЧАЙНО МОЩНОЫЕ ИЗВЕРЖЕ- НИЯ. ЛАНДШАФТ И КЛИМАТ РЕЗКО МЕНЯЮТСЯ. БОЛЬШИНСТВО НАСЕЛЕНИЯ СРАЗУ ПОГИБАЕТ ОТ СКАЧКОВ ТЕМПЕРАТУР, ЗЕМЛЕТРЯСЕНИЙ ИНАВОДНЕНИЙ. ПЕРЕЖИВ САМУЮ АКТИВНУЮ ФАЗУ В ОСОБО УКРЕПЛЕННОМ БУНКЕРЕ. ПОТОМ ВАС ЖДЕТ ГЛОБАЛЬНАЯ ЗАСУХА, РАЗРУШЕННЫЕ ГОРОДА И ПОСТОЯННАЯ СЕЙСМИЧЕСКАЯ АКТИВНОСТЬ. ВЫ СМОЖЕТЕ ВЫЖИТЬ, ТОЛЬКО РАЗРАБОТАВ СВЕРХУВСТВИТЕЛЬНУЮ ИНТЕЛЕКТУАЛЬНУЮ СИСТЕМУ ПРЕДСКАЗА- НИЯ ЗЕМЛЕТРЯСЕНИЙ И РОБОТИЗИРОВАННУЮ ИНФРАСТРУКТУРУ."),
			new Disaster(Id: 16, Description: "НАЧИНАЕТСЯ МАСШТАБНЫЙ ЯДЕРНЫЙ КОНФЛИКТ. РАДИОАКТИВНАЯ ПЫЛЬ ОКУ- ТАЕТ ВСЮ ПЛАНЕТУ, ЗАКРЫВ СОЛНЕЧНЫЙ СВЕТ, И НА ЗЕНЛЕ НАСТУПИТ ДОЛГАЯ ЯДЕРНАЯ ЗИМА. ПОЧТИ ВСЯ ТЕРРИТОРИЯ ПЛАНЕТЫ БУДЕТ ЗАРАЖЕНА РАДИАЦИЕЙ, ВЫЖИВШИХ ПОЧТИ НЕ ОСТАНЕТСЯ, ПОСЛЕ ВЫХОДАЩИЗ БУНКЕРА ВАМ ПРЕД- СТОИТ ОБУСТРОИТЬ ПОСТОЯННОЕ УБЕЖИ- ЩЕ, ОБЕСПЕЧИТЬ ПРОПИТАНИЕ И НАЧАТЬ ВОССТАНАВЛИВАТЬ ЖИЗНЬ НА ЗЕМЛЕ."),
			new Disaster(Id: 17, Description: "В РЕЗУЛЬТАТЕ МАСШТАБНОГО ПРИМЕНЕ- НИЯ ХИМИЧЕСКОГО ОРУЖИЯ СЕРЬЕЗНО МЕНЯЕТСЯ ЭКОЛОГИЧЕСКИЙ БАЛАНС. НАРУШЕН МИКРОБИОЛОГИЧЕСКИЙ СОСТАВ ПОЧВ И ВОДЫ, ОТРАВЛЕНЫ РАС- ТЕНИЯ, ПОГИБНУТ ПОЧТИ ВСЕ ЖИВОТНЫЕ ИЛЮДИ. ПОСЛЕ ВЫХОДА ИЗ БУНКЕРА БУДЕТ НЕПРОСТО ОБЕСПЕЧИТЬ СЕБЕ ПРОПИТА- НИЕ. ВАМ ПРИГОДЯТСЯ УЧЕНЫЕ И ИНЖЕНЕРЫ ДЛЯ ОБУСТРОЙСТВА ЖИЩ, И ФЕРМ.")
		);

		modelBuilder.Entity<Fact>().HasData(
			new Fact(Id: 1, Description: "АБЛЮТОФОБ - БОИТСЯ УМЫВАТЬСЯ"),
			new Fact(Id: 2, Description: "АНДРОФОБИЯ - БОИТСЯ МУЖЧИН"),
			new Fact(Id: 3, Description: "БЕЗОТКАЗНЫЙ"),
			new Fact(Id: 4, Description: "БРОДЯЖНИЧАЛ 2 ГОДА"),
			new Fact(Id: 5, Description: "ВЕРНУЛСЯ ИЗ ГОРЯЧЕЙ ТОЧКИ"),
			new Fact(Id: 6, Description: "ВЗЛОМАЛ БАЗУ ДАННЫХ ЦРУ"),
			new Fact(Id: 7, Description: "ВИДЕЛ ИНОПЛАНЕТЯН"),
			new Fact(Id: 8, Description: "ВЛАДЕЕТ 5 ЯЗЫКАМИ"),
			new Fact(Id: 9, Description: "ВРЕТ И ПРЕУВЕЛИЧИВАЕТ"),
			new Fact(Id: 10, Description: "ВЫРОС В СЕМЬЕ ЛЕСНИКА"),
			new Fact(Id: 11, Description: "ГИНОФОБИЯ - БОИТСЯ ЖЕНЩИН"),
			new Fact(Id: 12, Description: "ГИПНОТИЧЕСКАЯ УЛЫБКА"),
			new Fact(Id: 13, Description: "ГРЯЗНО РУГАЕТСЯ"),
			new Fact(Id: 14, Description: "ДЕРЖАЛ ДОМА 40 КОШЕК"),
			new Fact(Id: 15, Description: "ДУША КОМПАНИИ"),
			new Fact(Id: 16, Description: "ЗАНУДА"),
			new Fact(Id: 17, Description: "ЗАПУСТИЛ ИТ СТАРТАП"),
			new Fact(Id: 18, Description: "ЗНАЕТ АЗБУКУ МОРЗЕ"),
			new Fact(Id: 19, Description: "ЗНАЕТ ЛИЧНО ПРЕЗИДЕНТА"),
			new Fact(Id: 20, Description: "ЗНАЕТ НАИЗУСТЬ ВСЕ СТИХИ ПУШКИНА"),
			new Fact(Id: 21, Description: "ИЗВРАЩЕНЕЦ"),
			new Fact(Id: 22, Description: "ИСТЕРИЧНЫЙ"),
			new Fact(Id: 23, Description: "МАНЬЯК-УБИЙЦА"),
			new Fact(Id: 24, Description: "НАРКОДИЛЕР"),
			new Fact(Id: 25, Description: "НЕ ПУСКАЮТ В КАЗИНО"),
			new Fact(Id: 26, Description: "НОБЕЛЕВСКИЙ ЛАУРЕАТ ПО БИОИНЖЕНЕРИИ"),
			new Fact(Id: 27, Description: "НЫТИК"),
			new Fact(Id: 28, Description: "ОБЛАДАТЕЛЬ УНИКАЛЬНОГО СОПРАНО"),
			new Fact(Id: 29, Description: "ОСТАЛСЯ В ЖИВЫХ НА НЕОБИТАЕМОМ ОСТРОВЕ"),
			new Fact(Id: 30, Description: "ОТЧИСЛЕН ИЗ КЛУБА НАВЫКИ ВЫЖИВАНИЯ"),
			new Fact(Id: 31, Description: "ПИСАЕТСЯ ПО НОЧАМ"),
			new Fact(Id: 32, Description: "ПИШИТ С АШИПКАМИ"),
			new Fact(Id: 33, Description: "ПОБЕДИТЕЛЬ ПАРАОЛИМПИЙСКИХ ИГР"),
			new Fact(Id: 34, Description: "ПОДХОДИТ СЗАДИ И ДЫШИТ"),
			new Fact(Id: 35, Description: "ПОНИМАЕТ ЯЗЫК ЖИВОТНЫХ"),
			new Fact(Id: 36, Description: "ПРОДАЛ ПОЧКУ"),
			new Fact(Id: 37, Description: "ПРОШЕЛ 2 НЕДЕЛЬНЫЕ КУРСЫ ПСИХОЛОГА"),
			new Fact(Id: 38, Description: "ПСИХОПАТ"),
			new Fact(Id: 39, Description: "РАБОТАЛ В ЭСКОРТ УСЛУГАХ"),
			new Fact(Id: 40, Description: "РАЗГОВАРИВАЕТ С ДУХАМИ"),
			new Fact(Id: 41, Description: "СДЕЛАЕТ АЛКОГОЛЬ ИЗ ЧЕГО УГОДНО"),
			new Fact(Id: 42, Description: "СОСТОЯЛ В СЕКТЕ"),
			new Fact(Id: 43, Description: "СПЛЕТНИК"),
			new Fact(Id: 44, Description: "СТРОИЛ ПОДОБНЫЕ БУНКЕРЫ"),
			new Fact(Id: 45, Description: "ТЕЛЕПАТ"),
			new Fact(Id: 46, Description: "ТОЛЬКО ИЗ ОЧАГА ЭПИДЕМИИ"),
			new Fact(Id: 47, Description: "ТОРМОЗ"),
			new Fact(Id: 48, Description: "ХРАПИТ"),
			new Fact(Id: 49, Description: "ЧИТАЛ ВСЕ КНИГИ ЛАВКРАФТА"),
			new Fact(Id: 50, Description: "ЭРОТОФОБ -БОИТСЯ СЕКСА")
		);

		modelBuilder.Entity<Health>().HasData(
			new Health(Id: 1, Description: "АЛКОГОЛИЗМ"),
			new Health(Id: 2, Description: "БЕСПЛОДИЕ"),
			new Health(Id: 3, Description: "ГАЛЛЮЦИНАЦИИ"),
			new Health(Id: 4, Description: "ГИГАНТИЗМ ОТДЕЛЬНЫХ ЧАСТЕЙ ТЕЛА"),
			new Health(Id: 5, Description: "ГЛУХОЙ"),
			new Health(Id: 6, Description: "ДЕПРЕССИЯ"),
			new Health(Id: 7, Description: "ЗАВИСИМОСТЬ ОТ НАРКОТИКОВ"),
			new Health(Id: 8, Description: "ЗАИКА"),
			new Health(Id: 9, Description: "ИГРОВАЯ ЗАВИСИМОСТЬ"),
			new Health(Id: 10, Description: "ИДЕЛАЬНО ЗДОРОВ"),
			new Health(Id: 11, Description: "КАРЛИК"),
			new Health(Id: 12, Description: "КЛЕПТОМАНИЯ"),
			new Health(Id: 13, Description: "КОФЕЙНАЯ ЗАВИСИМОСТЬ"),
			new Health(Id: 14, Description: "ЛУНАТИЗМ"),
			new Health(Id: 15, Description: "МАНИЯ ПРЕСЛЕДОВАНИЯ"),
			new Health(Id: 16, Description: "МИГРЕНЬ"),
			new Health(Id: 17, Description: "НЕ ОБСЛЕДОВАЛСЯ"),
			new Health(Id: 18, Description: "НЕТ НОГИ"),
			new Health(Id: 19, Description: "НЕТ РУКИ"),
			new Health(Id: 20, Description: "ПОВЫШЕННАЯ ВОЛОСАТОСТЬ"),
			new Health(Id: 21, Description: "ПОНОС"),
			new Health(Id: 22, Description: "ПОТЕРЯ ОБОНЯНИЯ"),
			new Health(Id: 23, Description: "РАЗДВОЕНИЕ ЛИЧНОСТИ"),
			new Health(Id: 24, Description: "СЕКСУАЛЬНАЯ ОЗАБОЧЕННОСТЬ"),
			new Health(Id: 25, Description: "СКЛЕРОЗ"),
			new Health(Id: 26, Description: "СЛЕПОЙ"),
			new Health(Id: 27, Description: "СУИЦЫДАЛЬНЫЕ МЫСЛИ"),
			new Health(Id: 28, Description: "ТРЕМОР РУК"),
			new Health(Id: 29, Description: "ФРИГИДНОСТЬ,ИМПОТЕНЦИЯ"),
			new Health(Id: 30, Description: "ХВОСТ")
		);

		modelBuilder.Entity<Hobbie>().HasData(
			new Hobbie(Id: 1, Description: "АЛХИМИЯ"),
			new Hobbie(Id: 2, Description: "БОЕВЫЕ ИСКУСТВА"),
			new Hobbie(Id: 3, Description: "ВУАЙЕРИЗМ"),
			new Hobbie(Id: 4, Description: "ГИДРОПОНИКА"),
			new Hobbie(Id: 5, Description: "ГРИБЫ И ГОМЕОПАТИЯ"),
			new Hobbie(Id: 6, Description: "ДАЧНИК"),
			new Hobbie(Id: 7, Description: "ЗОЖ"),
			new Hobbie(Id: 8, Description: "КИНО И СЕРИАЛЫ"),
			new Hobbie(Id: 9, Description: "КОМПЬЮТЕРНЫЕ ИГРЫ"),
			new Hobbie(Id: 10, Description: "КРАЕВЕДЕНИЕ"),
			new Hobbie(Id: 11, Description: "ЛЮБИТЕЛЬСКАЯ РАДИОСВЯЗЬ"),
			new Hobbie(Id: 12, Description: "МАССАЖ И АКУПУНКТУРА"),
			new Hobbie(Id: 13, Description: "МЕДИТАЦИЯ"),
			new Hobbie(Id: 14, Description: "НАСТОЛЬНЫЕ ИГРЫ"),
			new Hobbie(Id: 15, Description: "НЕТВОРКИНГ"),
			new Hobbie(Id: 16, Description: "НЕТРАДИЦИОННАЯ МЕДИЦИНА"),
			new Hobbie(Id: 17, Description: "ОХОТА И РЫБАЛКА"),
			new Hobbie(Id: 18, Description: "ПАРКУР"),
			new Hobbie(Id: 19, Description: "ПИВОВАРЕНИЕ"),
			new Hobbie(Id: 20, Description: "ПИРОТЕХНИКА"),
			new Hobbie(Id: 21, Description: "РАЗГОВОРЫ ПО ДУШАМ"),
			new Hobbie(Id: 22, Description: "РОБОТОТЕХНИКА"),
			new Hobbie(Id: 23, Description: "СВИНГ-ВЕЧЕРИНКИ"),
			new Hobbie(Id: 24, Description: "СОВРЕМЕННОЕ ИСКУСТВО"),
			new Hobbie(Id: 25, Description: "СПОРТИВНЫЕ ТАНЦЫ"),
			new Hobbie(Id: 26, Description: "СТРИПТИЗ"),
			new Hobbie(Id: 27, Description: "УФОЛОГИЯ И МИСТИКА"),
			new Hobbie(Id: 28, Description: "ФЛУДИТЬ В ЧАТАХ"),
			new Hobbie(Id: 29, Description: "ХОЛОДНОЕ ОРУЖИЕ"),
			new Hobbie(Id: 30, Description: "ЧЕРНАЯ МАГИЯ")
		);

		modelBuilder.Entity<Luggage>().HasData(
			new Luggage(Id: 1, Description: "3 СЛИТКА ЗОЛОТА"),
			new Luggage(Id: 2, Description: "АНТИБИОТИКИ И ОБЕЗБОЛИВАЮЩЕЕ"),
			new Luggage(Id: 3, Description: "ГИТАРА"),
			new Luggage(Id: 4, Description: "ДЕФИБРИЛЛЯТОР"),
			new Luggage(Id: 5, Description: "ЗВУКОВАЯ ОТВЁРТКА"),
			new Luggage(Id: 6, Description: "ИНКУБАТОР С НАБОРОМ ЯИЦ"),
			new Luggage(Id: 7, Description: "ИНСТРУМЕНТЫ ЭЛЕКТРИКА"),
			new Luggage(Id: 8, Description: "КАПКАНЫ И НАБОР ЯДОВ"),
			new Luggage(Id: 9, Description: "КНИГИ АЙЗЕКА АЗИМОВА"),
			new Luggage(Id: 10, Description: "КОМПАС И КАРТА ОКРЕСНОСТЕЙ"),
			new Luggage(Id: 11, Description: "КУКЛА ВУДУ"),
			new Luggage(Id: 12, Description: "ЛУК И СТРЕЛЫ"),
			new Luggage(Id: 13, Description: "МЕШОК ЗЕРНА"),
			new Luggage(Id: 14, Description: "МЕШОК КАРТОШКИ"),
			new Luggage(Id: 15, Description: "МИЛЛИОН ДОЛЛАРОВ"),
			new Luggage(Id: 16, Description: "НАБОР ОТМЫЧЕК"),
			new Luggage(Id: 17, Description: "НАДУВНАЯ КУКЛА"),
			new Luggage(Id: 18, Description: "НАСТОЛЬНЫЕ ИГРЫ"),
			new Luggage(Id: 19, Description: "НОЖИ ДЛЯ МЕТАНИЯ"),
			new Luggage(Id: 20, Description: "НОУТБУК И ПЛАТЫ АРДУИНО"),
			new Luggage(Id: 21, Description: "ПЕРЕНОСНАЯ ЭЛЕКТРОСТАНЦИЯ"),
			new Luggage(Id: 22, Description: "ПИСТОЛЕТ"),
			new Luggage(Id: 23, Description: "ПРИБОР НОЧНОГО ВИДЕНИЯ"),
			new Luggage(Id: 24, Description: "САЖЕНЦЫ ФРУКТОВЫХ ДЕРЕВЬЕВ"),
			new Luggage(Id: 25, Description: "СНАЙПЕРСКАЯ ВИНТОВКА"),
			new Luggage(Id: 26, Description: "СПИРИТИЧЕСКАЯ ДОСКА"),
			new Luggage(Id: 27, Description: "СТОЛЯРНЫЕ ИНСТРУМЕНТЫ"),
			new Luggage(Id: 28, Description: "ЧЕМОДАНЧИК ФЕЛЬДШЕРА"),
			new Luggage(Id: 29, Description: "ШАПОЧКА ИЗ ФОЛЬГИ"),
			new Luggage(Id: 30, Description: "ЭНЦИКЛОПЕДИЯ ГРИБНИКА")
		);

		modelBuilder.Entity<Profession>().HasData(
			new Profession(Id: 1, Description: "АВТОМЕХАНИК"),
			new Profession(Id: 2, Description: "АДВОКАТ"),
			new Profession(Id: 3, Description: "АРХЕОЛОГ"),
			new Profession(Id: 4, Description: "БИОЛОГ"),
			new Profession(Id: 5, Description: "БРАКОНЬЕР"),
			new Profession(Id: 6, Description: "ВИДЕОИНЖЕНЕР"),
			new Profession(Id: 7, Description: "ВИРУСОЛОГ"),
			new Profession(Id: 8, Description: "ВОЕННЫЙ"),
			new Profession(Id: 9, Description: "ГОМЕОПАТ"),
			new Profession(Id: 10, Description: "ГРАБИТЕЛЬ"),
			new Profession(Id: 11, Description: "ДЕТЕКТИВ"),
			new Profession(Id: 12, Description: "ДИЗАЙНЕР"),
			new Profession(Id: 13, Description: "ДОМОХОЗЯЙКА"),
			new Profession(Id: 14, Description: "ЖУРНАЛИСТ"),
			new Profession(Id: 15, Description: "ЗНАХАРЬ"),
			new Profession(Id: 16, Description: "ИСТОРИК"),
			new Profession(Id: 17, Description: "КОУЧ"),
			new Profession(Id: 18, Description: "ЛЕСНИК"),
			new Profession(Id: 19, Description: "ЛЕТЧИК-ИНЖЕНЕР"),
			new Profession(Id: 20, Description: "МАРКЕТОЛОГ"),
			new Profession(Id: 21, Description: "МЕДСЕСТРА"),
			new Profession(Id: 22, Description: "МОДЕЛЬ"),
			new Profession(Id: 23, Description: "ПАПАРАЦЦИ"),
			new Profession(Id: 24, Description: "ПЕРЕВОДЧИК"),
			new Profession(Id: 25, Description: "ПИСАТЕЛЬ"),
			new Profession(Id: 26, Description: "ПОВАР"),
			new Profession(Id: 27, Description: "ПОЖАРНЫЙ"),
			new Profession(Id: 28, Description: "ПОЛИЦЕЙСКИЙ"),
			new Profession(Id: 29, Description: "ПРОГРАММИСТ"),
			new Profession(Id: 30, Description: "ПРОДАВЕЦ"),
			new Profession(Id: 31, Description: "ПСИХОЛОГ"),
			new Profession(Id: 32, Description: "РАЗНОРАБОЧИЙ"),
			new Profession(Id: 33, Description: "РОБОТОТЕХНИК"),
			new Profession(Id: 34, Description: "СЕКСОЛОГ"),
			new Profession(Id: 35, Description: "СПЕЦАГЕНТ"),
			new Profession(Id: 36, Description: "СТОМАТОЛОГ"),
			new Profession(Id: 37, Description: "СТРОИТЕЛЬ"),
			new Profession(Id: 38, Description: "СУДЬЯ"),
			new Profession(Id: 39, Description: "ТАТУ-МАСТЕР"),
			new Profession(Id: 40, Description: "ФЕРМЕР"),
			new Profession(Id: 41, Description: "ФИЗИК"),
			new Profession(Id: 42, Description: "ФИЛОСОФ"),
			new Profession(Id: 43, Description: "ХАКЕР"),
			new Profession(Id: 44, Description: "ХИМИК"),
			new Profession(Id: 45, Description: "ХИРУРГ"),
			new Profession(Id: 46, Description: "ЭКОЛОГ"),
			new Profession(Id: 47, Description: "ЭКСКУРСОВОД"),
			new Profession(Id: 48, Description: "ЭКСТРАСЕНС"),
			new Profession(Id: 49, Description: "ЭЛЕКТРИК"),
			new Profession(Id: 50, Description: "ЭТНОГРАФ"),
			new Profession(Id: 51, Description: "БЕЗРАБОТНЫЙ")
		);

		modelBuilder.Entity<SpecialCondition>().HasData(
			new SpecialCondition(Id: 1, Description: "РАЗЫГРАЙ КАРТУ, ТОЛЬКО ЕСЛИ ТЫ ИЗГНАН ПОКА ВСЕ БЫЛИ ОТВЛЕЧЕНЫ, ЧТО - ТО ПРОПАЛО ИЗ БУНКЕР, ЗАБЕРИ ЛЮБУЮ ОТКРЫТУЮ КАРТУ БУНКЕРА, ТЕПЕРЬ ОНА У ИЗГНАННЫХ"),
			new SpecialCondition(Id: 2, Description: "ВЫБРАННЫЙ ИГРОК ДО КОНЦА ИГРЫ НЕ ГОЛОСУЕТ ПРОТИВ ТЕБЯ"),
			new SpecialCondition(Id: 3, Description: "ЗАМЕНИ ЛЮБУЮ ОТКРЫТУЮ КАРТУ БУНКЕРА НА СЛУЧАЙНУЮ ИЗ КОЛОДЫ"),
			new SpecialCondition(Id: 4, Description: "ТВОЙ ГОЛОС СЧИТАЕТСЯ ЗА ДВА В ЭТОМ ГОЛОСОВАНИИ"),
			new SpecialCondition(Id: 5, Description: "СОБЕРИ ВСЕ ОТКРЫТЫЕ КАРТЫ БАГАЖА У НЕИЗГНАННЫХ ИГРОКОВ, ПЕРЕМЕШАЙ И ПЕРЕРАЗДАЙ"),
			new SpecialCondition(Id: 6, Description: "СОБЕРИ ВСЕ ОТКРЫТЫЕ КАРТЫ БИОЛОГИИ У НЕИЗГНАННЫХ ИГРОКОВ, ПЕРЕМЕШАЙ И ПЕРЕРАЗДАЙ"),
			new SpecialCondition(Id: 7, Description: "СОБЕРИ ВСЕ ОТКРЫТЫЕ КАРТЫ ЗДОРОВЬЯ У НЕИЗГНАННЫХ ИГРОКОВ, ПЕРЕМЕШАЙ И ПЕРЕРАЗДАЙ"),
			new SpecialCondition(Id: 8, Description: "СОБЕРИ ВСЕ ОТКРЫТЫЕ КАРТЫ ФАКТОВ У НЕИЗГНАННЫХ ИГРОКОВ, ПЕРЕМЕШАЙ И ПЕРЕРАЗДАЙ"),
			new SpecialCondition(Id: 9, Description: "СОБЕРИ ВСЕ ОТКРЫТЫЕ КАРТЫ ХОББИ У НЕИЗГНАННЫХ ИГРОКОВ, ПЕРЕМЕШАЙ И ПЕРЕРАЗДАЙ"),
			new SpecialCondition(Id: 10, Description: "ГОЛОС ВЫБРАННОГО ИГРАКА НЕ УЧИТЫВАЕТСЯ В ГОЛОСОВАНИИ"),
			new SpecialCondition(Id: 11, Description: "ЕСЛИ ТЕБЯ ИЗГНАЛИ ИГРОК СЛЕВА В СЛЕДУЮЩИЙ РАЗ ДОЛЖЕН ГОЛОСОВАТЬ ПРОТИВ СЕБЯ"),
			new SpecialCondition(Id: 12, Description: "ЕСЛИ ТЕБЯ ИЗГНАЛИ ИГРОК СПРАВА В СЛЕДУЮЩИЙ РАЗ ДОЛЖЕН ГОЛОСОВАТЬ ПРОТИВ СЕБЯ"),
			new SpecialCondition(Id: 13, Description: "ЕСЛИ ИЗГНАН САМЫЙ МЛАДШИЙ ИЗ ТЕХ У КОГО ОТКРЫТ ВОЗРАСТ, В СЛЕДУЮЩИЙ РАЗ ТЫ ДОЛЖЕН ГОЛОСОВАТЬ ЗА СЕБЯ"),
			new SpecialCondition(Id: 14, Description: "ЕСЛИ ИЗГНАН САМЫЙ СТАРШИЙ ИЗ ТЕХ У КОГО ОТКРЫТ ВОЗРАСТ, В СЛЕДУЮЩИЙ РАЗ ТЫ ДОЛЖЕН ГОЛОСОВАТЬ ЗА СЕБЯ"),
			new SpecialCondition(Id: 15, Description: "ГОЛОСА ПРОТИВ ВЫБРАННОГО ИГРОКА УДВАИВАЮТСЯ НО САМ ТЫ НЕ ГОЛОСУЕШЬ"),
			new SpecialCondition(Id: 16, Description: "ЗАБЕРИ КАРТУ БАГАЖА У ВЫБРАННОГО ИГРОКА"),
			new SpecialCondition(Id: 17, Description: "ВСЕ МОЛЧАТ ДО КОНЦА РАУНДА"),
			new SpecialCondition(Id: 18, Description: "ПОМЕНЯЙСЯ С ИГРОКОМ РЯДОМ С ТОБОЙ КАРТАМИ БАГАЖА"),
			new SpecialCondition(Id: 19, Description: "ПОМЕНЯЙСЯ С ИГРОКОМ РЯДОМ С ТОБОЙ КАРТАМИ БИОЛОГИИ"),
			new SpecialCondition(Id: 20, Description: "ПОМЕНЯЙСЯ С ИГРОКОМ РЯДОМ С ТОБОЙ КАРТАМИ ЗДОРОВЬЯ"),
			new SpecialCondition(Id: 21, Description: "ПОМЕНЯЙСЯ С ИГРОКОМ РЯДОМ С ТОБОЙ КАРТАМИ ФАКТОВ"),
			new SpecialCondition(Id: 22, Description: "ПОМЕНЯЙСЯ С ИГРОКОМ РЯДОМ С ТОБОЙ КАРТАМИ ХОББИ"),
			new SpecialCondition(Id: 23, Description: "ВСЕ ДОЛЖНЫ ПРОГОЛОСОВАТЬ ЗАНОВО, НО КАЖДЫЙ ВЫБИРАЕТ ДРУГОГО ИГРОКА"),
			new SpecialCondition(Id: 24, Description: "ВЫБИРИ ТИП КАРТ, ВСЕ ИГРОКИ В ЭТОТ РАУНД ОТКРЫВАЮТ ИМЕННО ЕЁ, ЕСЛИ ОНА НЕ ОТКРЫТА"),
			new SpecialCondition(Id: 25, Description: "ВЫБРОННЫЙ ИГРОК СТАНОВИТСЯ АБСОЛЮТНО ЗДОРОВ")
		);
	}
}
