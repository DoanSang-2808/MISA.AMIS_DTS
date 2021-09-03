<template>
  <div class="nav-bar">
    <div class="nav-bar-top">
      <a class="toggle"></a>
      <a class="logo">
        <img
          src="../../assets/img/Logo_Module_TiengViet_White.66947422.svg"
          width="96"
          height="32"
          alt=""
        />
      </a>
    </div>
    <div class="nav-bar-bottom scroll">
      <div class="item ">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-dashbroard"></div>
          </div>
          <div class="menu-icon-title">Tổng quan</div>
        </a>
      </div>
      <div class="item active">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-cash"></div>
          </div>
          <div class="menu-icon-title">Tiền mặt</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-bank"></div>
          </div>
          <div class="menu-icon-title">Tiền gửi</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-shopping"></div>
          </div>
          <div class="menu-icon-title">Mua hàng</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-sale"></div>
          </div>
          <div class="menu-icon-title">Bán hàng</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-bill"></div>
          </div>
          <div class="menu-icon-title">Quản lí hóa đơn</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-stock"></div>
          </div>
          <div class="menu-icon-title">Kho</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-tools"></div>
          </div>
          <div class="menu-icon-title">Công cụ dụng cụ</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-fixes-assets"></div>
          </div>
          <div class="menu-icon-title">Tài sản cố định</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-tax"></div>
          </div>
          <div class="menu-icon-title">Thuế</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-price"></div>
          </div>
          <div class="menu-icon-title">Giá thành</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-general"></div>
          </div>
          <div class="menu-icon-title">Tổng hợp</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-budget"></div>
          </div>
          <div class="menu-icon-title">Ngân sách</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-report"></div>
          </div>
          <div class="menu-icon-title">Báo cáo</div>
        </a>
      </div>
      <div class="item">
        <a href="" class="menu-item">
          <div class="menu-item-icon">
            <div class="icon24 icon-finance"></div>
          </div>
          <div class="menu-icon-title">Phân tích tài chính</div>
        </a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "NavBar",
  components: {},
};
</script>

<style scoped>
.nav-bar {
  width: 178px;
  height: 100%;
  background-color: #38393d;
}
.nav-bar-top {
  width: 100%;
  height: 48px;
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: 14px;
}
.nav-bar-top .toggle {
  width: 24px;
  height: 24px;
  margin-right: 10px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -424px -88px;
}
.nav-bar-bottom {
  height: calc(100% - 48px);
  width: 100%;
}
.scroll {
  width: 100%;
  height: 93%;
  margin: 0;
  overflow: auto;
}
.scroll::-webkit-scrollbar {
  width: 6px;
  height: 6px;
}
.scroll::-webkit-scrollbar-track {
  -webkit-box-shadow: inset 0 0 0 #ffffff;
  background: #fff;
  border: 0 solid #000;
}
::-webkit-scrollbar-thumb {
  -webkit-box-shadow: inset 0 0 0 #ffffff;
  background: #bbb;
  border-radius: 4px 4px 4px 4px;
}
.nav-bar-bottom .item {
  width: 100%;
  height: 42px;
  display: flex;
  align-items: center;
}
.active{
  background-color: #525357c4;
  border-left: 6px solid rgb(5, 182, 5)
}
.menu-item {
  border-left: 6px solid transparent;
  padding: 0 14px 0 8px;
  display: flex;
  color: #fff;
  text-decoration: none;
  font-family: inherit;
  font-size: 13px;
}
.menu-item-icon {
  width: 24px;
  margin-right: 8px;
}
.icon24 {
  height: 24px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
}
.icon-dashbroard {
  background-position: -30px -1630px;;
}
.icon-cash {
  background-position: -74px -1631px;
}
.icon-bank {
  background-position: -118px -1633px;;
}
.icon-shopping {
  background-position: -162px -1632px;
}
.icon-sale {
  background-position: -205px -1631px;
}
.icon-bill {
  background-position: -250px -1632px;
}
.icon-stock {
  background-position: -291px -1632px;
}
.icon-tools {
  background-position: -336px -1633px;
}
.icon-fixes-assets {
  background-position: -379px -1632px;
}
.icon-tax {
  background-position: -424px -1634px;
}
.icon-price {
  background-position: -468px -1633px;
}
.icon-general {
  background-position: -511px -1632px;
}
.icon-budget {
  background-position: -379px -1664px;
}
.icon-report {
  background-position: -549px -1636px;
}
.icon-finance {
  background-position: -204px -1667px;
}

</style>