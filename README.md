# SIMPEDO API (Sistem Monitoring Peternakan Domba)

## Deskripsi

SIMPEDO (Sistem Monitoring Peternakan Domba) adalah Web API berbasis ASP.NET Core yang digunakan untuk mengelola data peternakan domba, meliputi data pengguna, ternak, dan riwayat kondisi ternak.

Sistem ini memungkinkan pencatatan kondisi ternak secara berkala sehingga dapat dilakukan pemantauan perkembangan dan kesehatan ternak dari waktu ke waktu.

---

## Teknologi yang Digunakan

* C#
* ASP.NET Core Web API
* PostgreSQL
* Npgsql

---

## Cara Menjalankan

1. Clone repository
2. Setup database PostgreSQL
3. Import file SQL
4. Atur connection string di `appsettings.json`
5. Jalankan project
6. Akses melalui Swagger atau Postman

---

## Cara Import Database
1. Buka pgAdmin
2. Pilih database yang digunakan
3. Klik Query Tool
4. Copy isi file database.sql
5. Klik Execute

---

## Endpoint API

### User

| Method | Endpoint       | Deskripsi                 |
| ------ | -------------- | ------------------------- |
| GET    | /api/user      | Ambil semua user          |
| GET    | /api/user/{id} | Ambil user berdasarkan ID |
| POST   | /api/user      | Tambah user               |
| PUT    | /api/user/{id} | Update user               |
| DELETE | /api/user/{id} | Hapus user                |

---

### Ternak

| Method | Endpoint         | Deskripsi                   |
| ------ | ---------------- | --------------------------- |
| GET    | /api/ternak      | Ambil semua ternak          |
| GET    | /api/ternak/{id} | Ambil ternak berdasarkan ID |
| POST   | /api/ternak      | Tambah ternak               |
| PUT    | /api/ternak/{id} | Update ternak               |
| DELETE | /api/ternak/{id} | Hapus ternak                |

---

### Riwayat

| Method | Endpoint          | Deskripsi                    |
| ------ | ----------------- | ---------------------------- |
| GET    | /api/riwayat      | Ambil semua riwayat          |
| GET    | /api/riwayat/{id} | Ambil riwayat berdasarkan ID |
| POST   | /api/riwayat      | Tambah riwayat               |
| PUT    | /api/riwayat/{id} | Update riwayat               |
| DELETE | /api/riwayat/{id} | Hapus riwayat                |

---

### Endpoint Tambahan

| Method | Endpoint              | Deskripsi                                 |
| ------ | --------------------- | ----------------------------------------- |
| GET    | /api/ternak-with-user | Menampilkan data ternak beserta nama user |

---
