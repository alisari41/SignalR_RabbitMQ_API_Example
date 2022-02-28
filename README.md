
# Mail Gönderme sistemi 

Clinet göndermek istediği mesajı girecek. Mesajı Api dan gönderilmesi çok yorar fazla kişi mesaj gönderirse server bunu kaldıramaz. Gelen mesaj RabbitMQ mesaj kuyruk sistemine gönderilecek. Sonrasında sıralı bir şekilde Consumer yazılımında tek tek işleyip  mail atılcak. Atılan mail sonrasında real time da clientlarımıza haber vericeğiz.

![image](https://user-images.githubusercontent.com/81421228/155994144-66ae78fc-d8c0-418a-876a-07938e5c44ce.png)

## Demo

- Mesaj göndermek istediğiniz kişinin Email adresini ve göndereceğiniz mesajı giriniz.
![image](https://user-images.githubusercontent.com/81421228/155992445-6b57455e-8889-47d1-8a4f-3fd9597888c4.png)


- Mesaj Gönderildikten sonra Client'e bilgilendirme yapar
![image](https://user-images.githubusercontent.com/81421228/155992191-b90fec7f-042a-4da8-85a4-3d64e6bfc3f6.png)

  
