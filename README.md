 - !!!Задание без изменений от работодателя!!!

Дается на выполнение 24ч

API


Метод api для арифметических действий (только сумма) над валютами.
например:
10:евро + 12:долларов = X:бел.руб
json 
{
	summa: [ 
		{ currency : "euro", value: 10 },
		{ currency : "usd" , value: 12 }
	],
	resultCurrency : "byn"
}
структуру для хранения курсов валют надо придумать.
физическое хранилище для данных не определено.

Вычисляем курс на заданную дату.
Считаем, что хранилище всегда содержит актуальный курс на дату в запросе.

Это может быть консольное приложение. 
вызовы методов api может быть прямо из функции main.
