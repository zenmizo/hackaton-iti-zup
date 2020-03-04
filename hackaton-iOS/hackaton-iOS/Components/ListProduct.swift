//
//  ListProduct.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 04/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import Foundation
import BeagleUI

struct ListProductComponent: Widget {
    
    var appearance: Appearance?
    var flex: Flex?
    var accessibility: Accessibility?
    var id: String?
    
    var products: [Product]
    
    func toView(context: BeagleContext, dependencies: RenderableDependencies) -> UIView {
        let listProductView = ListProductView(context: context, beagleDependencies: dependencies)

        listProductView.show(self.products)
        listProductView.flex.setupFlex(flex)
        return listProductView
    }
    
}

struct ListProductEntity: ComponentEntity, ComponentConvertible {
    var products: [Product]
    
    func mapToComponent() throws -> ServerDrivenComponent {
        return ListProductComponent(products: products)
    }
    
}

