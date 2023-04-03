import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];

    constructor(public layoutService: LayoutService) { }

    ngOnInit() {
        this.model = [
            {
                label: 'Quản lý website',
                items: [
                    { label: 'Header', icon: 'pi pi-fw pi-home', routerLink: ['/cms/menu'] },
                    { label: 'Slider', icon: 'pi pi-fw pi-home', routerLink: ['/cms/slider'] },
                    { label: 'Về chúng tôi', icon: 'pi pi-fw pi-home', routerLink: ['/cms/ve-chung-toi'] },
                    { label: 'Thực đơn', icon: 'pi pi-fw pi-home', routerLink: ['/ms/thuc-don'] },
                    { label: 'Footer', icon: 'pi pi-fw pi-home', routerLink: ['/cms/footer'] },
                ]
            },
            {
                label: 'Quản lý bài viết',
                items: [
                    { label: 'Bài viết về chúng tôi', icon: 'pi pi-fw pi-home', routerLink: ['/cms/post/ve-chung-toi'] },
                ]
            },
            {
                label: 'Quản lý sản phẩm',
                items: [
                    { label: 'Danh mục sản phẩm', icon: 'pi pi-fw pi-home', routerLink: ['/cms/post'] },
                    { label: 'Sản phẩm', icon: 'pi pi-fw pi-home', routerLink: ['/cms/post'] },
                ]
            },
            {
                label: 'Quản lý chuỗi cửa hàng',
                items: [
                    {
                        label: 'Tỉnh',
                        icon: 'pi pi-fw pi-globe',
                        routerLink: ['/landing']
                    },
                    {
                        label: 'Quận/huyện/thành phố',
                        icon: 'pi pi-fw pi-globe',
                        routerLink: ['/landing']
                    },
                    { label: 'Cửa hàng', icon: 'pi pi-fw pi-home', routerLink: ['/cms/post'] },
                ]
            },
            {
                label: 'Quản lý tài khoản',
                icon: 'pi pi-fw pi-briefcase',
                items: [
                    {
                        label: 'Danh sách tài khoản',
                        icon: 'pi pi-fw pi-globe',
                        routerLink: ['/landing']
                    },
                    {
                        label: 'Thông tin tài khoản cá nhân',
                        icon: 'pi pi-fw pi-user',
                    }
                ]
            },
        ];
    }
}
