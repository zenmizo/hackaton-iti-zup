//
//  ListProductComponent.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 04/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import Foundation
import BeagleUI

struct ListProductScreen {

    func createScreen() -> Screen {
       let screen = Screen(
            navigationBar: getNavigation(),
              content: getBody()
        )
        return screen
    }
    
    func getNavigation() -> NavigationBar {
        
        return NavigationBar(title: "Coffee", showBackButton: false)
    }
    
    func getBody() -> ServerDrivenComponent {
        var children: [ServerDrivenComponent] = []
        
        children.append(getDescription(with: "FFFFFF"))
        if let products = getProducts() {
            children.append(products)
        }
        
        let container = Container(children: children)
        return container
    }
    
    func getDescription(with color: String) -> ServerDrivenComponent {
        var children: [ServerDrivenComponent] = []
        
        children.append(Text("The Science of Delicious"))
        
        children.append(Text("Amazing Coffees from arount the world!"))
        
        let size = Flex.Size(height: UnitValue(value: 150.0, type: UnitType.real))
        
        let flexDescriptions = Flex(flexDirection: Flex.FlexDirection.column,
                                    justifyContent: Flex.JustifyContent.center, alignItems: Flex.Alignment.center, size: size)
        
        let appear = Appearance(backgroundColor: color)
        
        return Container(children: children, flex: flexDescriptions, appearance: appear)
    }
    
    func getProducts() -> ServerDrivenComponent? {
        var products: [Product] = []
//        products.append(Product(name: "Café", description: "Café dos emirados arabes", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Chá", description: "Japanese", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Torrada", description: "Café dos emirados arabes", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Refrigerante", description: "Café dos emirados arabes", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Café", description: "Café dos emirados arabes", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Chá", description: "Japanese", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Torrada", description: "Café dos emirados arabes", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Refrigerante", description: "Café dos emirados arabes", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Café", description: "Café dos emirados arabes", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Chá", description: "Japanese", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Torrada", description: "Café dos emirados arabes", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
//        products.append(Product(name: "Refrigerante", description: "Café dos emirados arabes", imagePath: "https://marvel-live.freetls.fastly.net/canvas/2020/2/1974477c97a54aeca692c1df411d8771?quality=95&fake=.png"))
        do {
            let size = Flex.Size(width: UnitValue(value: 100, type: .percent), height: UnitValue(value: 80, type: .percent))
            return try ListProductComponent(flex: Flex(size: size),products: products)
        } catch {
            
        }
        return nil
    }
}
