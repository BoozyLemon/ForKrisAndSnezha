# Скрипт

Не стал тратить время на изменение скрипта, поэтому можете слегка поменять имена, но не поломайте скрипт

# Импорт

Импорт работает мговенно, если вы не меняли порядок колонок в скрипте и поменяли только имена

Не забудьте поставить Identity Specification для тех таблиц где тип данных у колонки Id - INT, если там стоит nvarchar или что-то еще, то Identity не ставить

![image](https://user-images.githubusercontent.com/60586479/113071514-8de74800-91cd-11eb-9cfb-32836f049ecc.png)

# Импорт картинок

Я не смог запихнуть массив байтов из базы в Excel, так что вам надо либо повторить код ниже на скрине, либо воспользоваться моим приложением

P.S. я в коде программы забыл добавить db.SaveChanges(); ошибок не будет, если вы забудете это сделать, но файлы не загрузятся

![image](https://user-images.githubusercontent.com/60586479/113071845-490fe100-91ce-11eb-87e7-1a625f11177b.png)

![image](https://user-images.githubusercontent.com/60586479/113071832-40b7a600-91ce-11eb-94bb-5178488185e9.png)
