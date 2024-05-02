Unity 2D SpaceShoot Project, features:
1) Cho phép người chơi điều khiển PlayerShip: <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/e2af413e-2008-4282-a599-eb1f031ec8b8"  width="25" /> 
   - Sử dụng các phím mũi tên trên bàn phím hoặc đầu vào cảm ứng (cho thiết bị di động hoặc JoyStick). (xử dụng Input Manager - 'Vertical' và "Horizontal" để nhận input từ mobile hoặc joystick)
   - Kỹ năng flip ship để xoay hướng 180 khi chiến đấu.
2) Triển khai việc di chuyển mượt mà của máy bay trên màn hình, cho phép người chơi điều hướng qua môi trường trò chơi:
   - Cho phép máy di chuyển lên xuống (vertical) và xoay đầu (Horizontal).
   - Camera sẽ chạy theo PlayerShip. 
3) Sinh ra máy bay kẻ thù hoặc các định dạng kẻ thù ở vị trí ngẫu nhiên theo khoảng thời gian hoặc dựa trên các kích hoạt cụ thể.
  - Kẻ thù EnemyShips : <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/4dd0eec6-00b6-43b2-87b9-8f47440ced8a" width="25" />, 
  - Kẻ thù Meteors : <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/69eaa0c3-1ae3-406f-b2b1-fab64dcd77de" width="25" />, <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/14bbb46b-5b7c-4181-bd00-dedfcb2d09c7" width="25" /> .
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

