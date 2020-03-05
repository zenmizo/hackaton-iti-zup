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

struct ListProductEntity: WidgetEntity {
    var flex: FlexEntity?
    
    var appearance: AppearanceEntity?
    
    var accessibility: AccessibilityEntity?
    
    var id: String?
    
    var products: [Product]
    
    func mapToComponent() throws -> ServerDrivenComponent {
        let flex = try? self.flex?.mapToUIModel()
        let appearance = try? self.appearance?.mapToUIModel()
        let accessibility = try? self.accessibility?.mapToUIModel()
            
        return ListProductComponent(appearance: appearance, flex: flex, accessibility: accessibility, products: products)
    }
    
}

