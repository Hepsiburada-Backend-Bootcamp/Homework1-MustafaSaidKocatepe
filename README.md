# Homework1-MustafaSaidKocatepe

Temel CRUD işlemlerinin yapılabildiği basit bir API projesi. GET-POST-PUT-PATCH işlemleri yapılabilir. Ayrıca verilen parametrelere göre kullanıcılar filtreli veya sıralı bir şekilde listelenebilir.

## Kurulum

```bash
git clone https://github.com/Hepsiburada-Backend-Bootcamp/Homework1-MustafaSaidKocatepe.git
```

## Örnek İstekler

Sort ile name, surname, email, telephone, createddate, isactive parametrelerinden birisi kullanılarak kullanıcılar sıralı bir şekilde alınabilir.
```bash
https://localhost:44325/v1/users/sort?sortParameter=name
```

Group ile name, surname, email, telephone, createddate, isactive parametrelerinden birisi kullanılarak kullanıcılar gruplu bir şekilde alınabilir.
```bash
https://localhost:44325/v1/users/sort?sortParameter=name
```

## Lisans
[MIT](https://choosealicense.com/licenses/mit/)
