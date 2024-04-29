Unity 2D SpaceShoot Project, features:
1) Cho phép người chơi điều khiển máy bay sử dụng các phím mũi tên trên bàn phím hoặc đầu vào cảm ứng (cho thiết bị di động). (xử dụng Input Manager - 'Vertical' và "Horizontal" để nhận input từ mobile hoặc joystick)
2) Triển khai việc di chuyển mượt mà của máy bay trên màn hình, cho phép người chơi điều hướng qua môi trường trò chơi:
   - Cho phép máy di chuyển lên xuống (vertical) và xoay đầu (Horizontal).
   - Camera sẽ chạy theo PlayerShip. 
3) Sinh ra máy bay kẻ thù hoặc các định dạng kẻ thù ở vị trí ngẫu nhiên theo khoảng thời gian hoặc dựa trên các kích hoạt cụ thể.
  - Kẻ thù EnemyShips : <img src="https://github.com/phatx88/SpaceShooter/assets/66936482/4dd0eec6-00b6-43b2-87b9-8f47440ced8a" width="10" />, 
  - Kẻ thù Meteors : ![meteorBrown_big1](https://github.com/phatx88/SpaceShooter/assets/66936482/69eaa0c3-1ae3-406f-b2b1-fab64dcd77de) , ![meteorBrown_small1](https://github.com/phatx88/SpaceShooter/assets/66936482/14bbb46b-5b7c-4181-bd00-dedfcb2d09c7)
  - Spawn location cho từng kẻ thù sẽ spawn ngoài màn hình, kẻ thù được lập trình để tiến về phía người chơi, hoặc chạy random.
  - Kẻ thù spawn theo thời gian được chọn và nhanh dần lên theo thời gian.
  - Khi Không còn người chơi spawnlocation sẽ ngưng spawn kẻ thù, kẻ thù còn lại sẽ tự xóa đi
  - Kẻ thù có layer khác nhau, kẻ thù cùng loại sẽ không tiêu diệt nhau
4) Máy bay địch có thể bắn đạn
  - Máy bay kẻ thù sẽ tìm người chơi và ở khoảng cách gần thì sẽ bắn người chơi.

