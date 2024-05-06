Unity 2D SpaceShoot Project, features:
1) Cho phép người chơi điều khiển PlayerShip: <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/e2af413e-2008-4282-a599-eb1f031ec8b8"  width="25" /> 
   - Sử dụng các phím mũi tên trên bàn phím hoặc đầu vào cảm ứng (cho thiết bị di động hoặc JoyStick). (xử dụng Input Manager - 'Vertical' và "Horizontal" để nhận input từ mobile hoặc joystick)
   - Kỹ năng flip ship để xoay hướng 180 khi chiến đấu.
2) Triển khai việc di chuyển mượt mà của máy bay trên màn hình, cho phép người chơi điều hướng qua môi trường trò chơi:
   - Cho phép máy di chuyển lên xuống (vertical) và xoay đầu (Horizontal).
   - Camera sẽ chạy theo PlayerShip. 
3) Sinh ra máy bay kẻ thù hoặc các định dạng kẻ thù ở vị trí ngẫu nhiên theo khoảng thời gian hoặc dựa trên các kích hoạt cụ thể.
   - Kẻ thù EnemyShips : <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/4dd0eec6-00b6-43b2-87b9-8f47440ced8a" width="25" />, <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/bd8df46d-6c1d-4993-80a5-3f9d1aca5717" width="25" />, <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/1bc885b1-56c6-414c-87e3-f68f270d4681" width="25" />, <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/3a9f62b4-b3de-4608-9f56-0de360a850cc" width="25" /> , <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/8357019b-bece-4c47-92a6-754f694a3e05" width="25" />, <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/366e3699-9882-476d-8eda-e2519b6ecef4" width="15" /> .
   - Kẻ thù Meteors : <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/69eaa0c3-1ae3-406f-b2b1-fab64dcd77de" width="15" />, <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/14bbb46b-5b7c-4181-bd00-dedfcb2d09c7" width="25" /> .
   - Spawn location cho từng kẻ thù sẽ spawn ngoài màn hình, kẻ thù được lập trình để tiến về phía người chơi, hoặc chạy random.
   - Kẻ thù spawn theo thời gian được chọn và nhanh dần lên theo thời gian.
   - Khi Không còn người chơi spawnlocation sẽ ngưng spawn kẻ thù, kẻ thù còn lại sẽ tự xóa đi.
   - Kẻ thù có layer khác nhau, kẻ thù cùng loại sẽ không tiêu diệt nhau.
4) Máy bay địch có thể bắn đạn
   - Máy bay kẻ thù sẽ truy tìm người chơi và kamikaze.
   - Khi đạt khoảng cách gần thì sẽ bắn người chơi và ngừng bắn khi ở quá xa hoặc không cùng hướng.
5) Hình nền động, tạo cảm giác bay cho các phi thuyền.
   - Tạo Background bằng Quad object (con lăn) khi di chuyển con lăn sẽ xoay theo các trục dẫn đến hiêu ứng di chuyển trên không gian.
   - Tạo nhiều hình background trồng lên và di chuyển trên lệch theo camera để tại hiệu ứng parallax.
6) Nhạc nền, và âm thanh hiệu ứng
   - Tạo AudioController để quản lý nhạc nền và SFX.
   - SFX khi bắn và trúng đạn và nổ.
   - SFX khi nhặt Power Ups.
7) Giao diện UI trước khi game bắt đầu và thông báo trong game
   - Màn hình Main Menu để Start Game hoặc Options(WIP).
   - Thông báo trong game (hint).
8) Máy bay địch chết khi trúng đạn và cộng điểm cho người chơi
   - Cộng điểm tùy theo dạng quân địch.
   -  <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/4dd0eec6-00b6-43b2-87b9-8f47440ced8a" width="25" /> : +10 điểm
   -  <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/69eaa0c3-1ae3-406f-b2b1-fab64dcd77de" width="25" />, <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/14bbb46b-5b7c-4181-bd00-dedfcb2d09c7" width="25" /> : +5 điểm
   -  <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/366e3699-9882-476d-8eda-e2519b6ecef4" width="10" /> : +1 điểm.
9) Người chơi có máu, mất dần khi va chạm địch hoặc trúng đạn
   - Player có 3 lives và 3 HP, nếu trúng đạn hay va chạm địch sẽ bị trừ 1HP.
   - Player bị mất 1 live nếu bị -3HP.
   - Lives và HP sẽ reset qua mỗi màn.
10) Giao diện UI với số điểm, số màn, số máu
   - Thanh Health Bar, số lives, số đạn đặc biệt
   - Số điểm của màn hiện tại, thời gian cho tới khi hết màn.
11) Game có nhiều cấp màn chơi, mỗi màn chơi có thể dễ dàng phân biệt được. Ví dụ, màu sắc, tốc độ, sát thương, số lượng địch,...
   - Game có 3 levels 
   - Mỗi level sẽ có thêm kẻ địch và các item Power Ups.
12) Hiệu ứng nổ khi có va chạm hoặc trúng đạn
   - ![pngegg](https://github.com/phatx88/SpaceShooter/assets/66936482/1e3509d9-4c2a-4229-a738-24d60dbc14d6)
   - Thực hiện animation cho tất cả collision.
13) Nhân vật có nhiều mạng (lượt chơi) và Bảng kết quả trò chơi, ghi lại số điểm mỗi lượt chơi và tổng điểm các lượt.
   - Player có 3 lives mỗi màn.
   - Khi hết thời gian, Panel Next level sẽ hiện ra, hiển thị tổng điểm các lượt chơi (total score) và kill counts (Total Kills).
   - Nếu player bị giết, Gameover Panel sẽ hiện ra.
14) Tái hiện một đội quân địch như tựa game classic (Theo một hay nhiều hàng)
   - <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/366e3699-9882-476d-8eda-e2519b6ecef4" width="15" /> : sẽ xuất hiện như đội hình classic (Pyramid Formation - có thể tùy chỉnh 1 hay nhiều hàng).
   - Tiêu diệt Spammer <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/b7af6816-5627-42f5-8027-6f0e59d2be43" width="25" />
 sẽ kích hoạt self desctruct cho tất cả <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/366e3699-9882-476d-8eda-e2519b6ecef4" width="15" /> con.
15) Nhặt Power-ups đạn nhiều góc bay cùng lúc
   - <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/c24f0e0c-f76a-4d36-b4d5-f5e9672be4f3" width="15" /> cho phép player bắn thêm 1 góc bay
   - Có tất cả là 16 Power Ups tương đương với 16 góc bay.
   - <img width="445" alt="SS_demo_01" src="https://github.com/phatx88/SpaceShooter/assets/66936482/db735fc9-f93a-4425-b1c0-9ab602bd0bd0">
   - Có thể tăng hay giảm Max Power Ups
16) Nhặt Power-ups đạn song song nhiều hàng
17) Nhặt Power-ups đạn truy vết (Khó)
   - <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/4860559c-b437-4d12-97a8-2548586b602c" width="15" /> cho phép player bắn 1 Missile Barrage bao gồm 36 Missiles (có thể tùy chỉnh tốc độ và góc quay).
   - Đạn Missile  <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/06c74d8a-922d-45ce-ace0-9234e560535d" width="10" /> sẽ truy tìm kẻ thù mang tag "Enemy" gần nhất.


